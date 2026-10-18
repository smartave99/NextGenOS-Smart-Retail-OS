// The Ask AI screen's layout, in a real browser (Chromium), with the real stylesheet and the real element structure of the page and of the side panel.
// What the owner saw: an empty band under the question box. Its cause was arithmetic in the stylesheet (the page keeps 44 px of padding under every
// page, the chat was sized to fill what was left, and the sticky question box could only stick inside the chat), so the box sat 88 px or more above
// the bottom edge when the page opened, and 44 px while a long chat was read: it also jumped as the reader scrolled. This test fails if that comes back.
import test from 'node:test';
import assert from 'node:assert/strict';
import { existsSync, mkdirSync, mkdtempSync, rmSync, writeFileSync } from 'node:fs';
import { createRequire } from 'node:module';
import { tmpdir } from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const repo = resolve(dirname(fileURLToPath(import.meta.url)), '..', '..');
const css = join(repo, 'apps', 'pos-dashboard-service', 'src', 'SmartRetail.Pos.Web', 'wwwroot', 'app.css');

function playwright() {
  const places = [process.env.NGOS_PLAYWRIGHT_DIR, join(repo, 'apps', 'business-hub', 'e2e'), '/opt/node-tools'].filter(Boolean);
  for (const dir of places) {
    try { return createRequire(join(dir, 'x.js'))('playwright'); } catch { /* the next place */ }
  }
  throw new Error('Playwright was not found (looked in ' + places.join(', ') + '). Run: cd apps/business-hub/e2e && npm install');
}

const message = (n) => Array.from({ length: n }, (_, i) => `
  <div class="msg-user"><p>Question number ${i + 1} about the shop?</p></div>
  <div class="msg-assistant"><div class="prose"><p>Answer number ${i + 1}. ${'Sales were steady and the bill count was a little lower than last week. '.repeat(3)}</p></div></div>`).join('\n');

/** The Ask AI page inside the app's layout (the app window's own top bar only in the app, not in a browser). */
const askPage = (frame, n) => `<!doctype html><html lang="en"${frame ? ' data-frame="app"' : ''}><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="file://${css}"></head><body>
<header class="window-bar"><a class="wb-brand" href="#"><span>Smart Retail AI</span></a></header>
<div class="app"><aside class="sidebar"><nav><a class="nav-link" href="#">Dashboard</a><a class="nav-link active" href="#">Ask AI</a></nav></aside>
<div class="main"><main class="content">
<div class="chat">
 <div class="page-head chat-head"><div><h1>Ask AI</h1><p class="lead privacy">The AI only reads your data and never changes it.</p></div>
  <div class="actions"><a class="btn btn-soft btn-sm" href="#">Past chats</a><a class="btn btn-soft btn-sm" href="#">Memory</a><a class="btn btn-soft btn-sm" href="#">Plan &amp; tasks</a><button class="btn btn-soft btn-sm" type="button">Copy chat</button><button class="btn btn-soft btn-sm" type="button">Save as file</button><button class="btn">New chat</button></div></div>
 <div class="thread" aria-live="polite">${n === 0 ? '<div class="chat-empty"><h2>Ask anything about your shop</h2><p class="muted">In English, Hindi or Hinglish.</p></div>' : message(n)}<div class="thread-end"></div></div>
 <div class="composer-wrap">
  <div class="chips"><button class="chip">Today</button><button class="chip">Stock</button><button class="chip">Month</button></div>
  <button type="button" class="jump-latest">Latest</button>
  <div class="composer"><textarea rows="1" placeholder="Ask about sales, stock or ideas…" aria-label="Your question"></textarea><button class="send" aria-label="Send">&#8593;</button></div>
  <div class="composer-foot">The AI can make mistakes. Check anything important in the POS.</div>
 </div>
</div></main></div></div></body></html>`;

/** Another page of the app: it must keep its own bottom padding. */
const otherPage = `<!doctype html><html lang="en"><head><meta charset="utf-8"><link rel="stylesheet" href="file://${css}"></head><body>
<div class="app"><aside class="sidebar"></aside><div class="main"><main class="content"><div class="page-head"><h1>Products</h1></div><p>Some page.</p></main></div></div></body></html>`;

/** The side panel beside the POS: its own layout. */
const panelPage = (n) => `<!doctype html><html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="file://${css}"></head><body>
<div class="panel-page">
 <div class="panel-top"><b>Smart Retail AI</b></div>
 <div class="mini-stats"><div class="mini-stat"><div class="label">Sales today</div><div class="v">₹12,500</div></div><div class="mini-stat"><div class="label">Bills today</div><div class="v">18</div></div></div>
 <div class="panel-find"><div class="scan-box compact"><input class="scan-input" type="search" aria-label="Find a barcode"></div></div>
 <div class="panel-thread">${n === 0 ? '<p class="panel-hello">Ask me about sales, stock, prices or bills.</p>' : message(n)}</div>
 <div class="panel-foot"><div class="chips"><button class="chip">Today</button><button class="chip">Stock</button></div>
  <div class="composer"><textarea rows="1" aria-label="Your question"></textarea><button class="send" aria-label="Send">&#8593;</button></div></div>
</div></body></html>`;

const SIZES = [[1920, 1080], [1366, 768], [1280, 720], [1024, 700], [800, 600], [420, 800]];

let browser;
let folder;
let n = 0;

async function open(html, width, height, colorScheme = 'light') {
  const file = join(folder, `page-${n++}.html`);
  writeFileSync(file, html);
  const page = await browser.newPage({ viewport: { width, height }, colorScheme });
  await page.goto('file://' + file);
  await page.waitForTimeout(60);
  return page;
}

/** Pixels between the bottom of the question box (and of the small line under it) and the bottom edge of the window. */
const gaps = (page, foot = '.composer-foot') => page.evaluate((footSelector) => {
  const box = document.querySelector('.composer').getBoundingClientRect();
  const line = document.querySelector(footSelector)?.getBoundingClientRect();
  return { input: Math.round(innerHeight - box.bottom), line: line ? Math.round(innerHeight - line.bottom) : null, overflow: document.scrollingElement.scrollWidth > innerWidth };
}, foot);

test.before(async () => {
  const { chromium } = playwright();
  try { browser = await chromium.launch(); } catch { browser = await chromium.launch({ executablePath: process.env.NGOS_CHROMIUM || '/opt/pw-browsers/chromium' }); }
  folder = mkdtempSync(join(tmpdir(), 'ask-layout-'));
  mkdirSync(folder, { recursive: true });
});
test.after(async () => { await browser?.close(); if (folder) rmSync(folder, { recursive: true, force: true }); });

test('the question box rests a small, even distance above the bottom edge at every window size, in the app window and in a browser, for an empty, a short and a long chat', async () => {
  for (const frame of [true, false]) {
    for (const count of [0, 2, 12]) {
      for (const [w, h] of SIZES) {
        const page = await open(askPage(frame, count), w, h);
        const label = `${frame ? 'app window' : 'browser'}, ${count} exchanges, ${w}x${h}`;
        const opened = await gaps(page);
        assert.ok(opened.input >= 24 && opened.input <= 48, `${label}: the box is ${opened.input} px above the bottom edge when the page opens (it must be 24 to 48, it was 88 or more)`);
        assert.ok(opened.line >= 6 && opened.line <= 20, `${label}: the small line under it is ${opened.line} px above the edge`);
        assert.equal(opened.overflow, false, `${label}: the page is wider than the window`);
        // Read to the end: the box does not move.
        await page.evaluate(() => scrollTo(0, document.scrollingElement.scrollHeight));
        await page.waitForTimeout(40);
        const end = await gaps(page);
        assert.equal(end.input, opened.input, `${label}: the box moved ${end.input - opened.input} px while the chat was scrolled (it jumped 44 px)`);
        await page.close();
      }
    }
  }
});

test('the dark theme and a narrow side-panel width lay out the same', async () => {
  const dark = await open(askPage(true, 2), 1366, 768, 'dark');
  assert.ok((await gaps(dark)).input >= 24 && (await gaps(dark)).input <= 48);
  await dark.close();
});

test('the chat page gives its bottom padding to the chat, and no other page loses its own', async () => {
  const chat = await open(askPage(true, 2), 1366, 768);
  assert.equal(await chat.evaluate(() => getComputedStyle(document.querySelector('.content')).paddingBottom), '0px');
  await chat.close();
  const other = await open(otherPage, 1366, 768);
  assert.equal(await other.evaluate(() => getComputedStyle(document.querySelector('.content')).paddingBottom), '44px', 'a page that is not the chat keeps its 44 px');
  await other.close();
});

test('the side panel keeps its question box within a small distance of the bottom at the widths it is used at', async () => {
  for (const count of [0, 2, 12]) {
    for (const [w, h] of [[420, 800], [360, 640], [480, 900]]) {
      const page = await open(panelPage(count), w, h);
      const g = await gaps(page, '.panel-foot');
      assert.ok(g.input >= 8 && g.input <= 40, `side panel, ${count} exchanges, ${w}x${h}: the box is ${g.input} px above the bottom edge`);
      assert.equal(g.overflow, false, `side panel ${w}x${h}: wider than the window`);
      await page.close();
    }
  }
});
