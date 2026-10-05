const fs = require('fs');
const path = require('path');

const known = new Set([
    'ANTHROPIC_API_KEY', 'BLOB_READ_WRITE_TOKEN', 'CLOUDINARY_API_KEY', 'CLOUDINARY_API_SECRET',
    'CLOUDINARY_CLOUD_NAME', 'DATABASE_URL', 'DATABASE_URL_2', 'DATABASE_URL_3', 'EDGE_CONFIG',
    'FIREBASE_CLIENT_EMAIL', 'FIREBASE_PRIVATE_KEY', 'FIREBASE_PROJECT_ID', 'GEMINI_API_KEY_1',
    'GEMINI_API_KEY_2', 'GEMINI_API_KEY_3', 'GROQ_API_KEY', 'GROQ_API_KEY_1', 'GROQ_API_KEY_10',
    'GROQ_API_KEY_2', 'GROQ_API_KEY_3', 'GROQ_API_KEY_4', 'GROQ_API_KEY_5', 'GROQ_API_KEY_6',
    'GROQ_API_KEY_7', 'GROQ_API_KEY_8', 'GROQ_API_KEY_9', 'NEXT_PUBLIC_CLOUDINARY_API_KEY',
    'NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME', 'NEXT_PUBLIC_FIREBASE_API_KEY', 'NEXT_PUBLIC_FIREBASE_APP_ID',
    'NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN', 'NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID',
    'NEXT_PUBLIC_FIREBASE_PROJECT_ID', 'NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET', 'NODE_ENV',
    'OPENAI_API_KEY', 'UPSTASH_REDIS_REST_TOKEN', 'UPSTASH_REDIS_REST_URL',
    'CLOUDINARY_CLOUD_NAME_1', 'CLOUDINARY_CLOUD_NAME_2', 'CLOUDINARY_CLOUD_NAME_3',
    'CLOUDINARY_API_KEY_1', 'CLOUDINARY_API_KEY_2', 'CLOUDINARY_API_KEY_3',
    'CLOUDINARY_API_SECRET_1', 'CLOUDINARY_API_SECRET_2', 'CLOUDINARY_API_SECRET_3',
    'KV_REST_API_READ_ONLY_TOKEN', 'KV_REST_API_TOKEN', 'KV_REST_API_URL', 'KV_URL', 'REDIS_URL'
]);

const suspects = new Set();
const ignore = ['NODE_MODULES', 'REACT_APP', 'VITE_', 'NEXT_PUBLIC', 'JSON', 'HTML', 'CSS', 'URL', 'API', 'KEY', 'SECRET', 'ID', 'UUID', 'STRING', 'BOOLEAN', 'NUMBER', 'TRUE', 'FALSE', 'NULL', 'UNDEFINED', 'GET', 'POST', 'PUT', 'DELETE', 'PATCH', 'OPTIONS', 'HEAD', 'ERROR', 'WARNING', 'INFO', 'DEBUG'];

const scan = (dir) => {
    if (!fs.existsSync(dir)) return;
    const files = fs.readdirSync(dir);
    for (const f of files) {
        const p = path.join(dir, f);
        if (fs.statSync(p).isDirectory()) {
            if (f !== 'node_modules' && f !== '.next' && f !== '.git' && f !== 'tmp') scan(p);
        } else if (f.match(/\.(ts|tsx|js|mjs|cjs|json|yml|yaml|md|txt|env.*)$/)) {
            const content = fs.readFileSync(p, 'utf8');

            // Look for standard dotenv patterns: KEY=VALUE or KEY="VALUE"
            const envMatches = content.matchAll(/^([A-Z0-9_]+)=/gm);
            for (const m of envMatches) {
                if (!known.has(m[1])) suspects.add(m[1]);
            }

            // Look for process.env destructuring: const { KEY_A, KEY_B } = process.env
            const destructureMatch = content.match(/\{([^}]+)\}\s*=\s*process\.env/g);
            if (destructureMatch) {
                for (const match of destructureMatch) {
                    const inner = match.replace(/\{|\}|\s*=\s*process\.env/g, '').split(',');
                    for (let word of inner) {
                        word = word.trim();
                        // handle renaming: const { A: b } = process.env
                        if (word.includes(':')) word = word.split(':')[0].trim();
                        if (word && !known.has(word)) suspects.add(word);
                    }
                }
            }

            // Look for process.env.ANYTHING
            const directMatches = content.matchAll(/process\.env\.([a-zA-Z0-9_]+)/g);
            for (const m of directMatches) {
                if (!known.has(m[1]) && m[1].toUpperCase() === m[1]) suspects.add(m[1]);
            }

            // Also look for NEXT_PUBLIC_ anything
            const nextMatches = content.matchAll(/(NEXT_PUBLIC_[A-Z0-9_]+)/g);
            for (const m of nextMatches) {
                if (!known.has(m[1])) suspects.add(m[1]);
            }
        }
    }
};

scan('.');
console.log(Array.from(suspects).sort().join('\n'));
