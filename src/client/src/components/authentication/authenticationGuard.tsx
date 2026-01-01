import { useEffect } from "react";
import { useMsal } from "@azure/msal-react";
import { useAuth } from "../../auth/useAuth";

export const AuthenticationGuard = ({ children }: { children: React.ReactNode }) => {
  const { account, login } = useAuth();
  const { inProgress } = useMsal();

  useEffect(() => {
    if (inProgress === "none" && !account) {
      login();
    }
  }, [inProgress, account]);

  if (!account) return null;

  return <>{children}</>;
};
