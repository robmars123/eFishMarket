import React from "react";
import { PLACEHOLDERIMAGE } from "../models/PlaceholderImage";
import { useParams } from "react-router-dom";
import { useProductById } from "../../hooks/useProductById";


export const ProductDetailPage: React.FC = () => {
  const { id } = useParams();
  const { product } = useProductById(id!);

  return (
    <div className="max-w-6xl mx-auto p-6 grid grid-cols-1 md:grid-cols-2 gap-10">
      
      {/* Left: Image Gallery */}
      <div>
        <img
          src={PLACEHOLDERIMAGE}
          alt="Selected"
          onError={(e) => (e.currentTarget.src = PLACEHOLDERIMAGE)}
          className="w-full rounded-lg shadow-md"
        />

        {/* <div className="flex gap-3 mt-4">
          {galleryImages.map((img, idx) => (
            <img
              key={idx}
              src={img}
              alt="thumbnail"
              onError={(e) => (e.currentTarget.src = PLACEHOLDERIMAGE)}
              onClick={() => setSelectedImage(img)}
              className={`w-20 h-20 object-cover rounded-md cursor-pointer border 
                ${img === selectedImage ? "border-blue-600" : "border-gray-300"}`}
            />
          ))}
        </div> */}
      </div>

      {/* Right: Product Details */}
      <div>
        <h1 className="text-3xl font-bold">{product?.name}</h1>

        <p className="text-2xl font-semibold text-gray-800 mt-2">
          ${product?.unitPrice}
        </p>

        <p className="text-yellow-500 mt-1">⭐ 5 / 5</p>

        <p className="text-gray-700 mt-4 leading-relaxed">
          SAMPLE DESCRIPTION
        </p>

        <button className="mt-6 bg-blue-600 text-white px-6 py-3 rounded-md hover:bg-blue-700 transition">
          Add to Cart
        </button>
      </div>
    </div>
  );
};