#!/usr/bin/env node
/**
 * Creates (or resets) the owner's sign-in for this website in Firebase Authentication.
 *
 *   OWNER_EMAIL=owner@shop.example OWNER_PASSWORD='a long password' node scripts/create-owner.js
 *
 * Uses the Firebase Admin settings in .env.local (FIREBASE_PROJECT_ID, FIREBASE_CLIENT_EMAIL, FIREBASE_PRIVATE_KEY).
 * The address must also be listed in OWNER_ADMIN_EMAILS (or be a staff member) to open the admin pages.
 * Nothing is built in: the e-mail and the password are given each time and are never stored by this script.
 */
const admin = require("firebase-admin");
const path = require("path");
const fs = require("fs");
const dotenv = require("dotenv");

const envPath = path.resolve(process.cwd(), ".env.local");
if (fs.existsSync(envPath)) dotenv.config({ path: envPath });

const email = (process.env.OWNER_EMAIL || "").trim().toLowerCase();
const password = process.env.OWNER_PASSWORD || "";
const fail = (message) => { console.error(message); process.exit(1); };

if (!/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(email)) fail("Set OWNER_EMAIL to the owner's e-mail address.");
if (password.length < 12 || !/[a-zA-Z]/.test(password) || !/[0-9]/.test(password)) fail("Set OWNER_PASSWORD: at least 12 characters, with letters and a number.");
if (!process.env.FIREBASE_PROJECT_ID || !process.env.FIREBASE_CLIENT_EMAIL || !process.env.FIREBASE_PRIVATE_KEY) fail("The Firebase Admin settings are missing from .env.local.");

admin.initializeApp({
    credential: admin.credential.cert({
        projectId: process.env.FIREBASE_PROJECT_ID,
        clientEmail: process.env.FIREBASE_CLIENT_EMAIL,
        privateKey: process.env.FIREBASE_PRIVATE_KEY.replace(/\\n/g, "\n"),
    }),
});

(async () => {
    const auth = admin.auth();
    try {
        const user = await auth.getUserByEmail(email);
        await auth.updateUser(user.uid, { password, emailVerified: true });
        console.log(`Password changed for ${email}.`);
    } catch (error) {
        if (error && error.code === "auth/user-not-found") {
            await auth.createUser({ email, password, emailVerified: true });
            console.log(`Owner ${email} created.`);
        } else {
            throw error;
        }
    }
    console.log("Remember: list this address in OWNER_ADMIN_EMAILS so that it may open the admin pages.");
})().catch((error) => fail(`Could not create the owner: ${error && error.message ? error.message : error}`));
