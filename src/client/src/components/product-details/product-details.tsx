import React from "react";
import { PLACEHOLDERIMAGE } from "../models/PlaceholderImage";
import { useParams } from "react-router-dom";
import { useProductById } from "../../hooks/useProductById";

export const ProductDetailPage: React.FC = () => {
  const { id } = useParams();
  const { product } = useProductById(id!);

  return (
    <div className="max-w-6xl mx-auto p-6 grid grid-cols-1 md:grid-cols-2 gap-10">
      
      {/* Left: Product Image */}
      <div className="flex justify-center items-start">
        <img
          src={PLACEHOLDERIMAGE}
          alt={product?.name || "Product"}
          onError={(e) => (e.currentTarget.src = PLACEHOLDERIMAGE)}
          className="w-full max-w-sm rounded-lg shadow-md"
        />
      </div>

      {/* Right: Product Details */}
      <div className="flex flex-col justify-between">
        <div>
          {/* Title */}
          <h1 className="text-3xl font-bold text-gray-900">
            {product?.name}
          </h1>

          {/* Price */}
          <p className="mt-2 text-2xl font-semibold text-blue-600">
            ${product?.unitPrice}
          </p>

          {/* Rating */}
          <div className="mt-2 flex items-center gap-2">
            <svg
              className="w-5 h-5 text-yellow-400"
              fill="currentColor"
              viewBox="0 0 20 20"
            >
              <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.286 3.957a1 1 0 00.95.69h4.162c.969 0 1.371 1.24.588 1.81l-3.37 2.448a1 1 0 00-.364 1.118l1.287 3.957c.3.921-.755 1.688-1.54 1.118l-3.37-2.448a1 1 0 00-1.175 0l-3.37 2.448c-.784.57-1.838-.197-1.539-1.118l1.287-3.957a1 1 0 00-.364-1.118L2.075 9.384c-.783-.57-.38-1.81.588-1.81h4.162a1 1 0 00.95-.69l1.286-3.957z" />
            </svg>
            <span className="text-sm text-gray-600">5 / 5</span>
          </div>

          {/* Description */}
          <p className="mt-4 text-gray-700 leading-relaxed">
            The Basic Tee 6-Pack allows you to fully express your vibrant personality with three grayscale options. Feeling adventurous? Put on a heather gray tee. Want to be a trendsetter? Try our exclusive colorway: "Black". Need to add an extra pop of color to your outfit? Our white tee has you covered.
          </p>
        </div>

        {/* Add to Cart */}
        <button className="mt-6 bg-blue-600 text-white py-3 px-6 rounded-md hover:bg-blue-700 transition">
          Add to Cart
        </button>
      </div>
    </div>
  );
};
