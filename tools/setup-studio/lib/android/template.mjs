// What the generic Android template (the app the release workflow builds once per release, the same for every customer) holds in the places where a customer's own values go.
// The template carries its own copy of these in assets/ngos-template.json (written by apps/storefront-web-mobile/scripts/android-config.mjs --template); this Studio reads that copy,
// so a newer template with other stand-in values still works. This list is what the tests and the fixture maker use, and a test says it is the same as the one the set-up script writes.
//
// None of these is ever shown to a shopper: each is replaced for every customer, and the finished app is checked to hold none of them.
export const TEMPLATE = {
  appId: 'com.nextgenos.templateapp',      // the application id (the app's identity on a phone and in the Play Store)
  namespace: 'com.nextgenos.shellapp',     // where the program's own classes live: it is NOT the application id, so changing the id never touches the program
  appName: 'Template App',                 // the name under the icon
  url: 'https://example.com',              // the customer's website address
  versionCode: 1,
  versionName: '1.0.0',
  accent: '#0071e3',                       // the accent colour of the small "you are offline" page inside the app
};
export const TEMPLATE_FILE = 'assets/ngos-template.json';
export const TEMPLATE_SCHEMA = 1;
