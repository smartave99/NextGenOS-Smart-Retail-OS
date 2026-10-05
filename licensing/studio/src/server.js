#!/usr/bin/env node
'use strict';
const config = require('./config').load();
const { createApp } = require('./app');

let app;
try {
  app = createApp(config);
} catch (e) {
  console.error('\nThe Licence Studio could not start:\n  ' + e.message + '\n');
  console.error('First time? Run:  node src/cli.js init\n');
  process.exit(1);
}

app.server.listen(config.port, config.host, () => {
  const where = config.host === '0.0.0.0' ? 'all network cards' : config.host;
  console.log(`\nNextGenOS Licence Studio is running.\n  Open:  http://${config.host === '0.0.0.0' ? 'localhost' : config.host}:${config.port}\n  Listening on: ${where}\n  Data folder:  ${config.dataDir}\n\nPress Ctrl+C to stop.\n`);
});

const stop = () => { console.log('Stopping...'); app.server.close(() => { app.db.close(); process.exit(0); }); setTimeout(() => process.exit(0), 3000).unref(); };
process.on('SIGINT', stop);
process.on('SIGTERM', stop);
