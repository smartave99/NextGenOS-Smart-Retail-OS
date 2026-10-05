#!/usr/bin/env python3
"""A stand-in for the parts of Supabase and GitHub that publish-update.sh talks to, for run.sh (never shipped).

Supabase Auth's password sign-in and Storage's upload, public download, list and delete, over https with a certificate
for shop.supabase.co, and GitHub's token service over plain http. It keeps the objects in memory and writes a log of
what the script asked for, in order, to --log when it is asked to stop (a request to /__stop).
"""
import argparse
import base64
import http.server
import json
import ssl
import threading
import urllib.parse

parser = argparse.ArgumentParser()
parser.add_argument("--port", type=int, required=True)
parser.add_argument("--cert", required=True)
parser.add_argument("--key", required=True)
parser.add_argument("--log", required=True)
parser.add_argument("--private", action="store_true", help="the folder is not public: public addresses answer 404")
args = parser.parse_args()

BUCKET = "app-updates"
ANON = "the-public-key"
EMAIL, PASSWORD, TOKEN = "uploader@example.com", "a long password", "uploader-token"
objects = {}
log = []


def b64(data):
    return base64.urlsafe_b64encode(data).decode().rstrip("=")


class Handler(http.server.BaseHTTPRequestHandler):
    protocol_version = "HTTP/1.1"

    def log_message(self, *_):
        pass

    def reply(self, code, body=b"", kind="application/json"):
        if isinstance(body, (dict, list)):
            body = json.dumps(body).encode()
        self.send_response(code)
        self.send_header("Content-Type", kind)
        self.send_header("Content-Length", str(len(body)))
        self.end_headers()
        if self.command != "HEAD":
            self.wfile.write(body)

    def body(self):
        return self.rfile.read(int(self.headers.get("Content-Length") or 0))

    def authorised(self):
        return self.headers.get("Authorization") == "Bearer " + TOKEN and self.headers.get("apikey") == ANON

    def do_POST(self):
        url = urllib.parse.urlparse(self.path)
        data = self.body()
        if url.path == "/auth/v1/token" and url.query == "grant_type=password":
            sent = json.loads(data or b"{}")
            ok = self.headers.get("apikey") == ANON and sent.get("email") == EMAIL and sent.get("password") == PASSWORD
            log.append({"call": "sign-in", "ok": ok})
            return self.reply(200, {"access_token": TOKEN}) if ok else self.reply(400, {"error": "invalid_grant"})
        if url.path == "/oidc":
            return self.reply(405)
        if url.path == "/storage/v1/object/list/" + BUCKET:
            if not self.authorised():
                return self.reply(401, {"error": "unauthorised"})
            log.append({"call": "list"})
            return self.reply(200, [{"name": name} for name in sorted(objects)])
        prefix = "/storage/v1/object/" + BUCKET + "/"
        if url.path.startswith(prefix):
            name = urllib.parse.unquote(url.path[len(prefix):])
            headers_ok = self.authorised() and self.headers.get("x-upsert") == "true"
            log.append({"call": "upload", "name": name, "bytes": len(data), "type": self.headers.get("Content-Type"), "ok": headers_ok})
            if not headers_ok:
                return self.reply(401, {"error": "unauthorised"})
            objects[name] = data
            return self.reply(200, {"Key": BUCKET + "/" + name})
        return self.reply(404)

    def do_DELETE(self):
        url = urllib.parse.urlparse(self.path)
        data = self.body()
        if url.path == "/storage/v1/object/" + BUCKET:
            if not self.authorised():
                return self.reply(401, {"error": "unauthorised"})
            names = json.loads(data)["prefixes"]
            log.append({"call": "delete", "names": names})
            for name in names:
                objects.pop(name, None)
            return self.reply(200, [{"name": name} for name in names])
        return self.reply(404)

    def do_GET(self):
        url = urllib.parse.urlparse(self.path)
        if url.path == "/__stop":
            with open(args.log, "w") as out:
                json.dump({"log": log, "objects": {name: len(data) for name, data in objects.items()}}, out)
            self.reply(200, b"stopped", "text/plain")
            threading.Thread(target=lambda: (plain.shutdown(), secure.shutdown())).start()
            return
        if url.path == "/oidc":
            if self.headers.get("Authorization") != "bearer request-token":
                return self.reply(401)
            audience = urllib.parse.parse_qs(url.query).get("audience", [""])[0]
            log.append({"call": "statement", "audience": audience})
            payload = b64(json.dumps({"aud": audience, "iss": "https://token.actions.githubusercontent.com"}).encode())
            return self.reply(200, {"value": b64(b'{"alg":"RS256"}') + "." + payload + "." + b64(b"signature")})
        prefix = "/storage/v1/object/public/" + BUCKET + "/"
        if url.path.startswith(prefix) and not args.private:
            name = urllib.parse.unquote(url.path[len(prefix):])
            if name in objects:
                return self.reply(200, objects[name], "application/octet-stream")
        return self.reply(404)


class Server(http.server.ThreadingHTTPServer):
    daemon_threads = True


secure = Server(("127.0.0.1", args.port), Handler)
context = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
context.load_cert_chain(args.cert, args.key)
secure.socket = context.wrap_socket(secure.socket, server_side=True)
plain = Server(("127.0.0.1", args.port + 1), Handler)
threading.Thread(target=plain.serve_forever, daemon=True).start()
secure.serve_forever()
