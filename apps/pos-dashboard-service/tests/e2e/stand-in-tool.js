// A stand-in for the command line of Claude Code ("claude") or Antigravity ("agy"), for the tests that look after them (jobs.e2e.js).
// The first argument says which tool it is standing in for. It answers --version; Antigravity answers "models" with its own list; "update" says
// it did nothing. STAND_IN_TOOL_LOG, if set, is a file that gets one line for every call.
const fs = require('fs');

const [tool, ...args] = process.argv.slice(2);
if (process.env.STAND_IN_TOOL_LOG) fs.appendFileSync(process.env.STAND_IN_TOOL_LOG, JSON.stringify({ tool, args }) + '\n');

if (args[0] === '--version') {
  console.log(tool === 'claude' ? '2.1.200 (Claude Code)' : 'agy 1.4.2');
} else if (tool === 'agy' && args[0] === 'models') {
  console.log('stand-in-large (the strongest)\nstand-in-small (fast)');
} else if (args[0] === 'update') {
  console.log('Already up to date.');
} else {
  console.error('stand-in tool: not expected: ' + args.join(' '));
  process.exit(1);
}
