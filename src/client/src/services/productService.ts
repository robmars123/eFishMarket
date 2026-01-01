import type { Product } from "../components/models/Product";

//Service is used to call external API
export interface PagedResponse<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}

export interface ApiClient { get<T>(url: string, signal?: AbortSignal): Promise<T>; }

export async function getPagedProducts(client: ApiClient, page: number, pageSize: number,signal?: AbortSignal
): Promise<PagedResponse<Product>> {
  const API_URL = import.meta.env.VITE_API_URL; 
  const url = `${API_URL}/getPagedProducts?page=${page}&pageSize=${pageSize}`; 
  return client.get<PagedResponse<Product>>(url, signal);
}

export async function getProductById( client: ApiClient, id: string, signal?: AbortSignal ): Promise<Product> { 
  const API_URL = import.meta.env.VITE_API_URL; 
  const url = `${API_URL}/getProductById?id=${id}`; 
  return client.get<Product>(url, signal); 
}