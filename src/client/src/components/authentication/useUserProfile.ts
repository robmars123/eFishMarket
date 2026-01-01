import { useMsal } from "@azure/msal-react";

export const useUserProfile = () => {
  const { accounts } = useMsal();
  const account = accounts[0];

  return {
    displayName: account?.name ?? null,
    email: account?.username ?? null,
    id: account?.localAccountId ?? null,
    raw: account
  };
};
