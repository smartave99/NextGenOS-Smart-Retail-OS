const fs = require('fs');
const path = require('path');

const keys = new Set();
const scan = (dir) => {
    if (!fs.existsSync(dir)) return;
    const files = fs.readdirSync(dir);
    for (const f of files) {
        const p = path.join(dir, f);
        if (fs.statSync(p).isDirectory()) {
            if (f !== 'node_modules' && f !== '.next' && f !== '.git') scan(p);
        } else if (f.match(/\.(ts|tsx|js|mjs|cjs)$/)) {
            const content = fs.readFileSync(p, 'utf8');
            const matches = content.matchAll(/process\.env\.([A-Za-z0-9_]+)/g);
            for (const m of matches) keys.add(m[1]);
            const matches2 = content.matchAll(/process\.env\[['"]([^'"]+)['"]\]/g);
            for (const m of matches2) keys.add(m[1]);
        } else if (f.match(/\.prisma$/)) {
            const content = fs.readFileSync(p, 'utf8');
            const matches = content.matchAll(/env\(['"]([^'"]+)['"]\)/g);
            for (const m of matches) keys.add(m[1]);
        }
    }
};
scan('src');
scan('scripts');
scan('prisma');

// Also scan next.config.ts and root files just in case
const rootFiles = fs.readdirSync('.');
for (const f of rootFiles) {
    if (fs.statSync(f).isFile() && f.match(/\.(ts|js|mjs|cjs)$/) && f !== 'extract_env.js') {
        const content = fs.readFileSync(f, 'utf8');
        const matches = content.matchAll(/process\.env\.([A-Za-z0-9_]+)/g);
        for (const m of matches) keys.add(m[1]);
    }
}

console.log(Array.from(keys).sort().join('\n'));
