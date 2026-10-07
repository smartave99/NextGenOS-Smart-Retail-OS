// Starts the website with the Node.js that is inside this folder. "Start Website.exe" (Windows) and "start-website.sh --app" (Linux) run it with --app: the website then opens as
// a program of its own (a window with no address bar and no terminal), and closing that window stops it. Without --app it runs in the terminal it was started from, for the person
// who looks after the website's computer ("Start Website (with a window, for problems).bat", "./start-website.sh").
'use strict';
const fs = require('fs');
const http = require('http');
const net = require('net');
const os = require('os');
const path = require('path');
const { spawn } = require('child_process');
const { pathToFileURL } = require('url');

const here = __dirname;
let appMode = false;

let info = {};
try { info = JSON.parse(fs.readFileSync(path.join(here, 'PACKAGE-INFO.json'), 'utf8')); } catch (e) { /* the folder is incomplete: the server file check below says so */ }

/** Where this website keeps its note that it is running, its window's profile and any problem note: one folder for each customer's website. */
function configDir() {
  const base = process.platform === 'win32'
    ? path.join(process.env.APPDATA || path.join(os.homedir(), 'AppData', 'Roaming'), 'NextGenOS Website')
    : path.join(process.env.XDG_CONFIG_HOME || path.join(os.homedir(), '.config'), 'nextgenos-website');
  return path.join(base, /^[a-z0-9][a-z0-9-]*$/.test(String(info.customer)) ? String(info.customer) : 'website');
}

function openWithSystem(target) {
  const [cmd, args] = process.platform === 'win32' ? ['cmd', ['/c', 'start', '""', target]] : process.platform === 'darwin' ? ['open', [target]] : ['xdg-open', [target]];
  try { spawn(cmd, args, { detached: true, stdio: 'ignore', windowsHide: true }).on('error', () => {}).unref(); } catch (e) { /* the message is printed anyway */ }
}

/** With no terminal a problem would be invisible: it is written in a note, and the note is opened. */
function showProblem(message) {
  try {
    const dir = configDir();
    fs.mkdirSync(dir, { recursive: true });
    const file = path.join(dir, 'Website problem.txt');
    fs.writeFileSync(file, 'The website could not start.\r\n\r\n' + message + '\r\n\r\nIf it keeps happening, send this note to the person who gave you the website.\r\n');
    openWithSystem(file);
  } catch (e) { /* nothing more can be done */ }
}

const stop = (message) => {
  console.error('\n' + message + '\n');
  if (appMode) showProblem(message);
  process.exit(1);
};

// What the person asked for: a port number, and whether other computers may open the website.
let port = 3000;
let portGiven = false;
let host = '127.0.0.1';
const args = process.argv.slice(2);
for (let i = 0; i < args.length; i += 1) {
  const a = args[i];
  if (/^\d+$/.test(a)) { port = Number(a); portGiven = true; }
  else if (a === '--port') { port = Number(args[++i]); portGiven = true; }
  else if (a === '--public') host = '0.0.0.0';
  else if (a === '--app') appMode = true;
  else if (a === '--host') host = String(args[++i] || '');
  else stop('I do not understand "' + a + '".\nTo start the website on this computer only:  start with no extra words.\nTo choose the port:  add the number, for example 8080.\nTo let other computers open it:  add --public\nTo open it as a program of its own (a window, no terminal):  add --app');
}
if (!Number.isInteger(port) || port < 1 || port > 65535) stop('The port must be a number from 1 to 65535, for example 8080.');
if (!host) stop('Say which address to listen on after --host, for example --host 127.0.0.1');

if (!fs.existsSync(path.join(here, 'app', 'server.js'))) stop('This folder is not complete: the website itself (app/server.js) is missing. Unpack the zip again, all of it, into a new folder.');

// The private settings (database address, passwords, keys) are read from private-settings.env if it is there. A value set in the computer's own settings wins.
// The public settings (name, address, country, kind of business, language, colours, logo) are the customer's own and are read when the website starts from the folder "customer" beside this program; they are not read from here.
const NEVER = new Set(['NODE_ENV', 'NGOS_DEV_UNLICENSED', 'NODE_OPTIONS', 'PORT', 'HOSTNAME']);
const file = path.join(here, 'private-settings.env');
if (fs.existsSync(file)) {
  const ignored = [];
  fs.readFileSync(file, 'utf8').split(/\r?\n/).forEach((raw) => {
    const line = raw.replace(/^\uFEFF/, '').trim();
    if (!line || line.startsWith('#')) return;
    const m = /^([A-Za-z_][A-Za-z0-9_]*)\s*=\s*(.*)$/.exec(line);
    if (!m) return;
    let value = m[2].trim();
    if (/^(".*"|'.*')$/.test(value) && value.length >= 2) value = value.slice(1, -1);
    if (m[1].startsWith('NEXT_PUBLIC_') || NEVER.has(m[1])) { ignored.push(m[1]); return; }
    if (value !== '' && process.env[m[1]] === undefined) process.env[m[1]] = value;
  });
  if (ignored.length) console.log('Ignored in private-settings.env (they are built in or set by the start command): ' + ignored.join(', '));
}

process.env.NODE_ENV = 'production';
process.env.PORT = String(port);
process.env.HOSTNAME = host;
process.env.NEXT_TELEMETRY_DISABLED = '1';
if (!process.env.LICENCE_DIR) process.env.LICENCE_DIR = path.join(here, 'licence');
// The customer's own settings are read, when the website starts, from the folder "customer" beside this program (the Setup Studio puts it there). No folder: the website is neutral.
if (!process.env.NGOS_CUSTOMER_DIR) process.env.NGOS_CUSTOMER_DIR = path.join(here, 'customer');
try { fs.mkdirSync(process.env.LICENCE_DIR, { recursive: true }); } catch (e) { stop('The folder for the licence cannot be made here (' + process.env.LICENCE_DIR + '). Unpack the website into a folder you may write to, such as your Documents or home folder, not into Program Files.'); }

// Is there room to work? The website keeps a cache of resized pictures.
try {
  const s = fs.statfsSync(here);
  if (s.bavail * s.bsize < 300 * 1024 * 1024) stop('There is less than 300 MB of free space on this disk. Free some space and start again.');
} catch (e) { /* the check is not possible on this system: carry on */ }

const hasLicence = Boolean(process.env.NGOS_LICENCE) || fs.existsSync(path.join(process.env.LICENCE_DIR, 'licence.ngos'));

/** Whether anything answers at this address (any answer at all: a website with no licence answers "not available"). */
const answers = (url) => new Promise((resolve) => {
  const req = http.get(url, (res) => { res.resume(); resolve(true); });
  req.on('error', () => resolve(false));
  req.setTimeout(3000, () => { req.destroy(); resolve(false); });
});
const portFree = (p) => new Promise((resolve) => { const s = net.createServer(); s.once('error', () => resolve(false)); s.listen(p, host, () => s.close(() => resolve(true))); });

/** As a program of its own: one copy at a time, in a window with no address bar, stopping when the window is closed. */
async function runAsProgram() {
  const dir = configDir();
  const win = await import(pathToFileURL(path.join(here, 'app-window.mjs')).href);
  const profileDir = path.join(dir, 'window');

  // Started again while it is open: bring up the window that is already there.
  const running = await win.findRunning(dir, { answers });
  if (running) {
    if (!win.openAppWindow(running.url, { profileDir })) stop('This computer has no Microsoft Edge, Google Chrome or Chromium to show the website in. Install one of them and start the website again.');
    process.exit(0);
  }

  // Port 3000 unless it is taken by something else; then any free port (the website is only for this computer here).
  let chosen = port;
  if (!(await portFree(chosen))) {
    if (portGiven) stop('Port ' + port + ' is already used by another program on this computer. Close that program, or start the website without a port number.');
    const s = net.createServer();
    await new Promise((resolve, reject) => { s.once('error', reject); s.listen(0, host, resolve); });
    chosen = s.address().port;
    await new Promise((resolve) => s.close(resolve));
  }
  const url = 'http://127.0.0.1:' + chosen;
  process.env.PORT = String(chosen);
  process.on('uncaughtException', (e) => stop('The website stopped because of a problem:\n' + (e && e.stack ? e.stack : e)));
  process.chdir(path.join(here, 'app'));
  require(path.join(here, 'app', 'server.js'));

  let ready = false;
  for (let i = 0; i < 300 && !ready; i += 1) { ready = await answers(url); if (!ready) await new Promise((resolve) => setTimeout(resolve, 300)); }
  if (!ready) stop('The website did not start within 90 seconds.');

  win.writeRunning({ url, folder: here }, dir);
  // With no licence yet, the window opens on the page where the key is typed: a window with no address bar has nowhere to type that address.
  let window = win.openAppWindow(hasLicence ? url : url + '/admin/licence', { profileDir });
  const shutdown = () => { win.clearRunning(dir); try { if (window) window.child.kill(); } catch (e) { /* it is already closed */ } process.exit(0); };
  process.on('SIGINT', shutdown);
  process.on('SIGTERM', shutdown);
  if (!window) { win.clearRunning(dir); stop('This computer has no Microsoft Edge, Google Chrome or Chromium to show the website in. Install one of them and start the website again.'); }
  window.closed.then((ended) => {
    if (win.windowWasClosedByPerson(ended)) return shutdown();
    // The browser ended at once: it handed the page to another program, or could not start. A website that nobody can see or stop must not stay running.
    win.clearRunning(dir);
    return stop('The window for the website could not be opened. Close every Microsoft Edge or Chrome window and start the website again.');
  });
}

if (appMode) {
  runAsProgram().catch((e) => stop('The website could not start: ' + (e && e.message ? e.message : e)));
  return;
}

const probe = net.createServer();
probe.once('error', (e) => {
  if (e.code === 'EADDRINUSE') stop('Port ' + port + ' is already used by another program on this computer.\nClose that program, or start the website on another port, for example 8080.');
  if (e.code === 'EACCES') stop('This computer does not let the website use port ' + port + '. Use a number above 1024, for example 8080.');
  if (e.code === 'EADDRNOTAVAIL') stop('This computer has no address ' + host + '.');
  stop('The website could not start listening: ' + e.message);
});
probe.listen(port, host, () => probe.close(() => {
  const shown = host === '0.0.0.0' ? '127.0.0.1' : host;
  console.log('\n' + (info.name || 'The website') + (info.version ? ' (version ' + info.version + ')' : ''));
  console.log('Starting. In a few seconds you can open it in a web browser at:\n\n    http://' + shown + ':' + port + '\n');
  console.log('Leave this window open while the website is in use. To stop the website, close this window (or press Ctrl+C).');
  if (host === '0.0.0.0') console.log('Other computers can open it too, at this computer\'s address and port ' + port + '.');
  if (!hasLicence) console.log('\nThere is no licence yet, so the website shows a page saying it is not available. Open http://' + shown + ':' + port + '/admin/licence and type the licence key you were given,\nor put the licence file (licence.ngos) in the folder "licence".');
  process.on('uncaughtException', (e) => { console.error('\nThe website stopped because of a problem:\n' + (e && e.stack ? e.stack : e)); process.exit(1); });
  process.chdir(path.join(here, 'app'));
  require(path.join(here, 'app', 'server.js'));
}));
