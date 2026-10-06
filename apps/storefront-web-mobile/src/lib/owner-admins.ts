/**
 * The owner(s) of a deployment: the people who may sign in to the admin pages before any staff member exists.
 * They are named in the setting OWNER_ADMIN_EMAILS (comma separated) when the site is set up for a customer; nothing is built
 * into the code. An owner must still sign in with a VERIFIED e-mail address, like everybody else.
 */
export function ownerAdminEmails(): string[] {
    return (process.env.OWNER_ADMIN_EMAILS || "")
        .split(",")
        .map((e) => e.trim().toLowerCase())
        .filter((e) => e.includes("@"));
}

export function isOwnerAdmin(email: string | null | undefined): boolean {
    if (!email) return false;
    return ownerAdminEmails().includes(email.trim().toLowerCase());
}
