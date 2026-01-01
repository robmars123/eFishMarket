import { useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";

export const useAuth = () => {
  const { instance, accounts } = useMsal();

  const login = async () => {
    return instance.loginPopup(loginRequest);
  };

  const logout = async () => {
    return instance.logoutPopup();
  };

  const getToken = async () => {
    const account = accounts[0];

    if (!account) {
      throw new Error("No account found. User must log in first.");
    }

    const response = await instance.acquireTokenSilent({
      ...loginRequest,
      account
    });

    return response.accessToken;
  };

  return { login, logout, getToken, account: accounts[0] };
};
