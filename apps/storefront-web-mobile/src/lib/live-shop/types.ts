// What the shop PC sends (Smart Retail POS: OwnerLive and OwnerDay). Figures only: never a customer's name or phone
// number, nor what was on a bill.

export interface OwnerToday {
    day: string; // "2026-09-27"
    sales: number;
    bills: number;
    credit: number; // still owed on today's bills
    lastBillAt: string | null; // "18:57"
    vsLastWeek: number | null; // 0.12 for 12% more than the same day last week
    comparedAt: string | null; // "18:58" when compared with last week by this time of day
    lastWeekSales: number;
}

export interface OwnerHour { hour: number; sales: number; bills: number; lastWeekSales?: number }
export interface OwnerBill { number: string; time: string | null; total: number; due: number; later: boolean }
export interface OwnerDaySales { day: string; sales: number; bills: number }
export interface OwnerProduct { name: string; qty: number; sales: number }
export interface OwnerStock { name: string; left: number; reorderAt: number }
export interface OwnerFinding { kind: string; title: string | null; now: boolean }

export interface OwnerLive {
    version: number;
    shop: string;
    demo: boolean;
    sentAt: string;
    today: OwnerToday;
    hours: OwnerHour[];
    bills: OwnerBill[];
    week: OwnerDaySales[];
    top: OwnerProduct[];
    lowStock: OwnerStock[];
    fixNow: { count: number; items: OwnerFinding[] };
}

export interface OwnerDay {
    day: string;
    sales: number;
    bills: number;
    returns: number;
    hours: OwnerHour[];
    top: OwnerProduct[];
}

/**
 * The Monday review, as the shop PC sends it every hour (Smart Retail POS: OwnerReview, kept as the `review` row of
 * `shop_reports`). Figures and product names only; the owner's decisions and notes stay at the shop.
 */
export interface OwnerWeek {
    from: string; // "2026-09-21", a Monday
    to: string; // "2026-09-27", the Sunday
    sales: number; // with GST
    bills: number;
    averageBill: number;
    profit: number | null; // before GST; null when no purchase price is known
    margin: number | null; // 0.19 for 19% of the sales it was worked out on
}

export interface OwnerRunningOut { name: string; inHand: number; perDay: number | null; daysLeft: number | null }
export interface OwnerNotSelling { name: string; inHand: number; value: number }

export interface OwnerReview {
    demo: boolean;
    thisWeek: OwnerWeek;
    weekBefore: OwnerWeek;
    yearBefore: OwnerWeek | null; // null when the POS has no bills from then
    runningOut: OwnerRunningOut[];
    notSelling: OwnerNotSelling[];
    reviewedOn: string | null; // the day the week was marked as reviewed at the shop
}

export interface Shop { id: string; name: string }

export interface ShopPc {
    id: string;
    label: string;
    connected_at: string;
    last_seen_at: string | null;
    /** The shop's main PC, which speaks for the shop; the others are counters. Missing when the project's script is older. */
    is_main?: boolean;
}

/** The shop's AI's answer, as the shop PC sends it (Smart Retail POS: OwnerAnswer). */
export interface OwnerAnswer {
    text: string;
    columns: string[];
    rows: (string | number | boolean | null)[][];
    totalRows: number;
    source: string | null;
}

/** A question the owner asked the shop's AI, and its answer when there is one. */
export interface ShopQuestion {
    id: string;
    question: string;
    status: "waiting" | "working" | "answered" | "failed";
    answer: OwnerAnswer | null;
    asked_at: string;
    answered_at: string | null;
}

/** The five photos Smart Retail POS makes of a product, in the order it makes them. */
export type PhotoKind = "white" | "in-use" | "european-model" | "indian-model" | "east-asian-model";

/**
 * A finished product as the shop PC offers it for the website (Smart Retail POS: WebsiteProductData): the listing's words,
 * the POS's prices (never an AI's) and the category of this website the shop PC chose. Nothing about customers, bills or stock.
 */
export interface ShopOffer {
    name: string; // the one name for customers, written by the shop's AI
    description: string;
    price: number; // what the customer pays, from the POS
    originalPrice: number | null; // the MRP, only when it is above the price
    highlights: string[];
    specifications: { key: string; value: string }[];
    tags: string[];
    categoryId: string; // a main category of this website, or "" when none was chosen
    subcategoryId: string; // one of its subcategories, or ""
    categoryPath: string; // "Grocery › Oils", for the owner to read
    barcode: string | null; // the maker's barcode, when the POS has one
    posName: string; // what the POS calls it, so the owner knows which product it is
    code: string; // its code in the POS
}

/** Where a product stands on the waiting list: its photos arriving, waiting for the owner, or decided on. */
export type ShopProductState = "sending" | "waiting" | "published" | "declined";

/** One row of the waiting list (`shop_products`). */
export interface ShopProduct {
    key: string; // the product's number in the POS
    offer: ShopOffer;
    state: ShopProductState;
    photoKinds: PhotoKind[]; // the photos the shop PC has for it
    sentAt: Date;
    decidedAt: Date | null;
}

/** A photo waiting with the product (`shop_product_photos`): a picture as base64 text, kept only until the owner decides. */
export interface ShopPhoto {
    kind: PhotoKind;
    mime: "image/jpeg" | "image/png" | "image/webp";
    content: string;
}

/** A category of this website, as it keeps them: a main category, or a subcategory of one (`parentId`). */
export interface SiteCategory {
    id: string;
    name: string;
    parentId: string | null;
}

/** A place a product can go on this website: a main category, or a subcategory under one. */
export interface CategoryChoice {
    categoryId: string;
    subcategoryId: string;
    label: string; // "Grocery" or "Grocery › Oils"
}
