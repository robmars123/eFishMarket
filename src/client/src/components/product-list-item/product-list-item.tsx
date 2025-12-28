import React from "react";
import type { Product } from "../models/Product";
import { Link } from "react-router-dom";

interface Props {
  product: Product;
}

export const ProductListItem: React.FC<Props> = ({ product }) => {
  return (
    <Link
      to={`/products/${product.id}`}
      className="block max-w-sm border rounded-lg p-4 shadow-sm bg-white hover:shadow-md transition"
    >
      <div className="w-full rounded-md flex items-center justify-center h-40 bg-gray-100 text-gray-500 text-sm mb-4">
        No Image Available
      </div>

      <h2 className="mt-3 text-xl font-semibold">{product.name}</h2>

      <p className="text-lg font-bold text-gray-800 mt-1">
        ${product.unitPrice}
      </p>

      <p className="text-gray-600 mt-2">test product description</p>
    </Link>
  );
};