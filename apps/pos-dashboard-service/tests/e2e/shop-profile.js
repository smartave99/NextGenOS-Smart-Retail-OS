// A customer's AI profile (profile/ai.json) for the browser tests. The product has no default customer: what pictures and posters show comes from this file,
// so the tests that look at it say whose they are. This one is a shop in India with a Hindi second line (the legacy POS's customers).
const fs = require('fs');
const path = require('path');

const indiaShop = {
  schema: 1,
  country: { code: 'IN', name: 'India' },
  shopKind: 'a small shop',
  images: {
    models: [
      { title: 'European model', looks: 'European' },
      { title: 'Indian model', looks: 'Indian, with a fair complexion' },
      { title: 'East Asian model', looks: 'East Asian' },
    ],
    festivals: ['Diwali', 'Navratri', 'Dussehra', 'Durga Puja', 'Dhanteras', 'Chhath', 'Christmas', 'New Year', 'Makar Sankranti', 'Pongal', 'Holi', 'Eid', 'Raksha Bandhan', 'Ganesh Chaturthi', 'Onam'],
    localLanguage: {
      name: 'Hindi', tag: 'hi',
      lines: { clearance: 'भारी छूट · सीमित स्टॉक', 'new-arrivals': 'नया माल आ गया है', 'best-sellers': 'सबकी पसंद', 'festival-offer': 'त्योहार पर खास दाम' },
    },
  },
};

/** Writes <folder>/profile/ai.json and returns the settings that make the app read it. */
function writeShopProfile(folder, profile = indiaShop) {
  fs.mkdirSync(path.join(folder, 'profile'), { recursive: true });
  fs.writeFileSync(path.join(folder, 'profile', 'ai.json'), JSON.stringify(profile, null, 2));
  return { Ai__ProfileFolder: folder };
}

module.exports = { indiaShop, writeShopProfile };
