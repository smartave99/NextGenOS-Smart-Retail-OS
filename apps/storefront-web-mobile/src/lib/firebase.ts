/* eslint-disable @typescript-eslint/no-explicit-any */
import { initializeApp, getApps, getApp } from "firebase/app";
import { getAuth } from "firebase/auth";
import { getAnalytics, isSupported } from "firebase/analytics";
import { getPerformance } from "firebase/performance";

const firebaseConfig = {
    apiKey: process.env.NEXT_PUBLIC_FIREBASE_API_KEY,
    authDomain: process.env.NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN,
    projectId: process.env.NEXT_PUBLIC_FIREBASE_PROJECT_ID,
    storageBucket: process.env.NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET,
    messagingSenderId: process.env.NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID,
    appId: process.env.NEXT_PUBLIC_FIREBASE_APP_ID,
};

let app: any = null;
let auth: any = null;
let analytics: any = Promise.resolve(null);
let perf: any = null;

const hasFirebaseConfig = Boolean(
    firebaseConfig.apiKey &&
    firebaseConfig.authDomain &&
    firebaseConfig.projectId &&
    firebaseConfig.appId,
);

if (hasFirebaseConfig) {
    try {
        app = getApps().length > 0 ? getApp() : initializeApp(firebaseConfig);
        auth = getAuth(app);

        if (typeof window !== "undefined") {
            analytics = isSupported().then((supported: boolean) => supported ? getAnalytics(app) : null);
            perf = getPerformance(app);
        }
    } catch (error) {
        // Authentication is optional for the public storefront. Keep the shop
        // usable and let authenticated screens show their own configuration error.
        console.warn("Firebase services are unavailable.", error);
        app = null;
        auth = null;
        analytics = Promise.resolve(null);
        perf = null;
    }
}

export { app, auth, analytics, perf };
