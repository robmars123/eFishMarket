import type { Product } from "../components/Product";

//Service is used to call external API
export interface PagedResponse<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}

export async function getPagedProducts(
  page: number,
  pageSize: number,
  signal?: AbortSignal
): Promise<PagedResponse<Product>> {
  //uses .env file for global environment variables
  const API_URL = import.meta.env.VITE_API_URL;

  const response = await fetch(
    `${API_URL}/getPagedProducts?page=${page}&pageSize=${pageSize}`,
    { signal }
  );

  if (!response.ok) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  return response.json();
}
