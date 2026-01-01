import { useAuth } from "../auth/useAuth";
import type { ApiClient } from "../services/productService";

export const useApiClient = (): ApiClient => {
  const { account, getToken } = useAuth();

  const get = async <T>(url: string, signal?: AbortSignal): Promise<T> => {
    let token: string | null = null;

    if (account) { 
        token = await getToken(); 
    }

    const response = await fetch(url, {
      signal,
      headers: {
        Authorization: `Bearer ${token}`
      }
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json() as Promise<T>;
  };

  return { get };
};
