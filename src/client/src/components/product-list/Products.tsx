import { useState } from "react";
import type { Product } from "../models/Product";
import { useProducts } from "../../hooks/useProducts";
import styles from "./products.module.css";
import { ProductListItem } from "../product-list-item/product-list-item";

export function Products() {
  const [page, setPage] = useState(1);
  const pageSize = 10;

  const { products, error, loading } = useProducts(page, pageSize);

  if (loading) return <p className={styles.loading}>Loading products...</p>;
  if (error) return <p className={styles.error}>Error: {error}</p>;

return (
  <div className="max-w-6xl mx-auto px-4 py-8">
    <h1 className="text-3xl font-bold text-gray-800 mb-6">Products Catalog</h1>

    {/* product list */}
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
      {products.map((p: Product) => (
        <ProductListItem
          product={{
            id: p.id,
            name: p.name,
            unitPrice: Number(p.unitPrice).toFixed(2)
          }}
        />
      ))}
    </div>

    {/* pagination */}
    <div className="flex items-center justify-center gap-4 mt-8">
      <button
        className="px-4 py-2 bg-gray-200 text-gray-700 rounded hover:bg-gray-300 disabled:opacity-50"
        disabled={page === 1}
        onClick={() => setPage(page - 1)}>
        Previous
      </button>

      <span className="text-gray-600 font-medium">Page {page}</span>

      <button
        className="px-4 py-2 bg-gray-200 text-gray-700 rounded hover:bg-gray-300"
        onClick={() => setPage(page + 1)}>
        Next
      </button>
    </div>
  </div>
);
}
