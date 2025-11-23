import { useState } from "react";
import type { Product } from "./Product";
import { useProducts } from "../hooks/useProducts";

export function Products() {
  const [page, setPage] = useState(1);
  const pageSize = 10;

  //use hook file
  const { products, error, loading } = useProducts(page, pageSize);

  if (loading) return <p>Loading products...</p>;
  if (error) return <p style={{ color: "red" }}>Error: {error}</p>;

  //display
  return (
    <div>
      {products.length > 0 ? (
        <>
          {products.map((p: Product) => (
            <div key={p.id}>
              {p.name} — ${p.unitPrice}
            </div>
          ))}
          <div style={{ marginTop: "1rem" }}>
            <button disabled={page === 1} onClick={() => setPage(page - 1)}>
              Previous
            </button>
            <button onClick={() => setPage(page + 1)}>Next</button>
          </div>
        </>
      ) : (
        <p>No products found</p>
      )}
    </div>
  );
}
