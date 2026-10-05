const { app, BrowserWindow } = require('electron');
const path = require('path');
const { createServer } = require('http');
const { parse } = require('url');

// Determine if we are running the packaged app or in development
const isPackaged = app.isPackaged;

let mainWindow;
let nextServer;

async function startNextJSServer() {
  const next = require('next');
  const dev = !isPackaged;
  const dir = __dirname;
  
  const nextApp = next({ dev, dir });
  const handle = nextApp.getRequestHandler();

  await nextApp.prepare();

  nextServer = createServer((req, res) => {
    const parsedUrl = parse(req.url, true);
    handle(req, res, parsedUrl);
  });

  return new Promise((resolve) => {
    nextServer.listen(3000, () => {
      console.log('> Next.js server ready on http://localhost:3000');
      resolve();
    });
  });
}

async function createWindow() {
  mainWindow = new BrowserWindow({
    width: 1280,
    height: 800,
    // Explicitly assigning the requested logo to the desktop app window
    icon: path.join(__dirname, 'public', 'logo.png'),
    webPreferences: {
      nodeIntegration: true,
      contextIsolation: false
    }
  });

  // Hide the default menu for a more native app feel
  mainWindow.setMenuBarVisibility(false);

  // Load the local Next.js server we just started
  mainWindow.loadURL('http://localhost:3000');

  mainWindow.on('closed', () => {
    mainWindow = null;
  });
}

app.on('ready', async () => {
  try {
    await startNextJSServer();
    createWindow();
  } catch (error) {
    console.error('Failed to start Next.js server:', error);
  }
});

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit();
  }
});

app.on('before-quit', () => {
  if (nextServer) {
    nextServer.close();
  }
});
