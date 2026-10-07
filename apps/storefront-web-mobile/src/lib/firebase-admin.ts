import { cert, getApp, getApps, initializeApp, type App } from "firebase-admin/app";
import { getAuth, type Auth } from "firebase-admin/auth";
import { getFirestore, type Firestore } from "firebase-admin/firestore";
import { getStorage, type Storage } from "firebase-admin/storage";
import { getSettings } from "@/lib/customer/settings";

/**
 * Starts Firebase Admin the first time it is needed. With no (or incomplete) settings it returns null, and the getters below
 * then hand back an object that refuses every call: a site that is not set up never pretends that a login or a save worked.
 */
function getAdminApp(): App | null {
    if (getApps().length) return getApp();
    try {
        const firebaseAdminConfig = {
            projectId: process.env.FIREBASE_PROJECT_ID,
            clientEmail: process.env.FIREBASE_CLIENT_EMAIL,
            // Replace literal search for \n with actual newline character for PEM key
            privateKey: process.env.FIREBASE_PRIVATE_KEY?.replace(/\\n/g, "\n"),
        };

        if (!firebaseAdminConfig.projectId || !firebaseAdminConfig.clientEmail || !firebaseAdminConfig.privateKey) {
            console.error("Firebase Admin Error: Missing environment variables. Check .env.local");
            throw new Error("Missing Firebase Admin environment variables");
        }

        return initializeApp({
            credential: cert(firebaseAdminConfig),
            storageBucket: getSettings().firebase.storageBucket || undefined,
        });
    } catch (error) {
        console.error("Firebase Admin Initialization Failed:", error);
        return null;
    }
}

/** An object that stands in for a service that is not set up: every use of it fails with a clear message. */
function notConfigured<T extends object>(service: string): T {
    const refuse = () => {
        throw new Error(`Firebase Admin ${service} is not configured`);
    };
    return new Proxy({} as T, {
        get: (_target, property) => (property === "then" || typeof property === "symbol" ? undefined : refuse),
    });
}

export function getAdminAuth(): Auth {
    const app = getAdminApp();
    return app ? getAuth(app) : notConfigured<Auth>("Auth");
}

export function getAdminDb(): Firestore {
    const app = getAdminApp();
    return app ? getFirestore(app) : notConfigured<Firestore>("Firestore");
}

export function getAdminStorage(): Storage {
    const app = getAdminApp();
    return app ? getStorage(app) : notConfigured<Storage>("Storage");
}
