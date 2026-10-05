// Stands in for the Codex CLI in codexupdate.e2e.js. It only answers what the Codex update card asks of Codex: its version
// (from the file STAND_IN_CODEX_VERSION_FILE, which the test changes), its own help, and whether it is signed in.
const fs = require('fs');

const args = process.argv.slice(2);

const top = `Codex CLI

Usage: codex [OPTIONS] [PROMPT]
       codex [OPTIONS] <COMMAND>

Commands:
  exec        Run Codex non-interactively [aliases: e]
  login       Manage login
  app-server  Run the app server

Options:
  -m, --model <MODEL>
      --search   Enable live web search
`;

const exec = ['--image', '--skip-git-repo-check', '--ephemeral', '--sandbox', '--color', '--cd', '--output-last-message',
  '--output-schema', '--model', '--config', '--enable'];

const login = `Manage login

Commands:
  status  Show login status

Options:
      --device-auth
      --with-api-key <KEY>
`;

if (args[0] === '--version') {
  console.log('codex-cli ' + fs.readFileSync(process.env.STAND_IN_CODEX_VERSION_FILE, 'utf8').trim());
} else if (args[0] === '--help') {
  console.log(top);
} else if (args[0] === 'exec' && args[1] === '--help') {
  console.log('Run Codex non-interactively\n\nOptions:\n' + exec.map(flag => `      ${flag} <VALUE>  something`).join('\n'));
} else if (args[0] === 'login' && args[1] === '--help') {
  console.log(login);
} else if (args[0] === 'login' && args[1] === 'status') {
  console.log('Logged in using ChatGPT (stand-in)');
} else {
  console.error('stand-in codex (Codex update test): not expected: ' + args.join(' '));
  process.exit(3);
}
