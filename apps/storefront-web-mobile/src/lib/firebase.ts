/* eslint-disable @typescript-eslint/no-explicit-any */
import { initializeApp, getApps, getApp } from "firebase/app";
import { getAuth } from "firebase/auth";
import { getAnalytics, isSupported } from "firebase/analytics";
import { getPerformance } from "firebase/performance";
import { getSettings } from "@/lib/customer/settings";

// The public parts of the customer's own Firebase project: their settings (the customer folder, read when the website starts), not values built into the program.
const own = getSettings().firebase;
const firebaseConfig = {
    apiKey: own.apiKey,
    authDomain: own.authDomain,
    projectId: own.projectId,
    storageBucket: own.storageBucket,
    messagingSenderId: own.messagingSenderId,
    appId: own.appId,
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
