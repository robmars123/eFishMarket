import { useEffect, useState } from "react";
import { getProductById } from "../services/productService";
import type { Product } from "../components/models/Product";

// A custom hook in React is essentially a wrapper around a service
// (or any reusable logic) so that your component stays lean and focused on rendering.
export function useProductById(id: string) {
  const [product, setProduct] = useState<Product | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  // useEffect is a React Hook that lets you perform side effects in function components.
  // A side effect is any operation that affects something outside the scope of the current
  // function render — such as fetching data, subscribing to events, manipulating the DOM, or setting up timers.
  useEffect(() => {
    const controller = new AbortController();

    loadProduct(id, controller);

    return () => controller.abort();
  }, [id]);

  async function loadProduct(id: string, controller: AbortController) {
    try {
      setLoading(true);
      setError(null);

      const data = await getProductById(id, controller.signal);
      setProduct(data);
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

  return { product, error, loading };
}