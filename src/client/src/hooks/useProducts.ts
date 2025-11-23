import { useEffect, useState } from "react";
import type { Product } from "../components/Product";
import { getPagedProducts } from "../services/productService";

//A custom hook in React is essentially a wrapper around a service
//(or any reusable logic) so that your component stays lean and focused on rendering.
export function useProducts(page: number, pageSize: number) {
  const [products, setProducts] = useState<Product[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  //useEffect is a React Hook that lets you perform side effects in function components. 
  //A side effect is any operation that affects something outside the scope of the current 
  //function render — such as fetching data, subscribing to events, manipulating the DOM, or setting up timers.
  useEffect(() => {
    const controller = new AbortController();
    
    loadProducts(page, pageSize, controller);

    return () => controller.abort();
  }, [page, pageSize]);

  async function loadProducts(page: number, pageSize: number, controller: AbortController) {
      try {
        setLoading(true);
        setError(null);
        const data = await getPagedProducts(page, pageSize, controller.signal);
        setProducts(data.items ?? []);
      } catch (err: unknown) {
        if (err instanceof Error) {
          if (err.name === "AbortError") {
            // expected cancellation, do nothing
            return;
          }
          setError(err.message);
        } else {
          setError("An unexpected error occurred");
        }
      } finally {
        setLoading(false);
      }
    }

  return { products, error, loading };
}
