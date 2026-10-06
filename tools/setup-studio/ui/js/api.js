// Talking to the Studio's server. The secret in the address is kept for this tab, and sent with every request.
const params = new URLSearchParams(location.search);
export const key = params.get('k') || sessionStorage.getItem('studio-key') || '';
if (key) { try { sessionStorage.setItem('studio-key', key); } catch { /* private window */ } }
if (params.has('k')) history.replaceState(null, '', location.pathname + location.hash);

export const session = { id: sessionStorage.getItem('studio-session') || '', me: null, can: {} };
export function setSession(id) { session.id = id || ''; try { id ? sessionStorage.setItem('studio-session', id) : sessionStorage.removeItem('studio-session'); } catch { /* private window */ } }
export const onSignedOut = { run: () => {} };

export class ApiError extends Error { constructor(message, status, code, details) { super(message); this.status = status; this.code = code; this.details = details; } }

export async function api(method, path, body, { raw = false } = {}) {
  let res;
  try {
    res = await fetch(path, { method, headers: { 'x-studio-key': key, ...(session.id ? { 'x-studio-session': session.id } : {}), ...(body !== undefined ? { 'content-type': 'application/json' } : {}) }, body: body === undefined ? undefined : JSON.stringify(body) });
  } catch { throw new ApiError('The Studio is not answering. Is it still open on this PC?', 0, 'offline'); }
  if (raw && res.ok) return res;
  let json = null;
  try { json = await res.json(); } catch { /* not JSON */ }
  if (!res.ok) {
    if (res.status === 401 && json?.code === 'signin') { setSession(''); onSignedOut.run(); }
    throw new ApiError(json?.error ?? `Something went wrong (${res.status}).`, res.status, json?.code, json?.details);
  }
  return json;
}
export const get = (p) => api('GET', p);
export const post = (p, b = {}) => api('POST', p, b);
export const put = (p, b = {}) => api('PUT', p, b);
export const del = (p) => api('DELETE', p);
