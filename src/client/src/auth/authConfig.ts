// MSAL configuration for Microsoft Entra ID authentication

export const authConfig = {
  auth: {
    clientId: "a807f80a-fa69-45aa-ab32-49ccc24383b9", // Replace with your actual Application (client) ID
    authority: "https://login.microsoftonline.com/a663a91d-6646-468f-a4d5-db1639e09bd4", // Replace with your actual Tenant ID
    redirectUri: "/", // Adjust if using a specific route like "/auth/callback"
  },
  cache: {
    cacheLocation: "localStorage", // or "sessionStorage"
    storeAuthStateInCookie: false, // set to true if issues with IE11 or legacy browsers
  }
};

// Optional: scopes for token acquisition
export const loginRequest = {
  scopes: ["openid", "profile","api://a807f80a-fa69-45aa-ab32-49ccc24383b9/Products.ReadWrite"] // Replace with your actual API scope
};
