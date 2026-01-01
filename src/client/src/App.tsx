import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from "./components/navigation-bar/navigation-bar";
import { Products } from "./components/product-list/Products";
import { ProductDetailPage } from "./components/product-details/product-details";
import { AuthenticationGuard } from "./components/authentication/authenticationGuard";

function App() {
  return (
    <BrowserRouter>
      <Navbar />

      <Routes>
        <Route
          path="/"
          element={
              <Products />
          }
        />

        <Route
          path="/products/:id"
          element={
            <AuthenticationGuard>
              <ProductDetailPage />
            </AuthenticationGuard>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;