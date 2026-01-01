import { useAuth } from "../../auth/useAuth";
import { useUserProfile } from "../authentication/useUserProfile";

export default function Navbar() {
  const { displayName } = useUserProfile();
  const { account, login, logout } = useAuth();

  return (
    <nav className="w-full bg-white border-b shadow-sm">
      <div className="max-w-7xl mx-auto px-4 py-3 flex items-center justify-between">
        
        <div className="text-2xl font-bold text-gray-800">
          ShopEase
        </div>

        <div className="hidden md:flex items-center gap-6 text-gray-700 font-medium">
          <a href="/" className="hover:text-gray-900">Catalog</a>
          <a href="/about" className="hover:text-gray-900">About</a>
          <a href="/contact" className="hover:text-gray-900">Contact</a>
        </div>

        {/* User + Cart */}
        <div className="flex items-center gap-4">
          {/* Display name when logged in */}
          {account && (
            <span className="text-gray-700 font-medium">
              Welcome, {displayName}
            </span>
          )}
          {/* Only show if logged in */}
          {!account && ( 
            <button onClick={login} className="text-sm text-blue-600 hover:text-blue-800 font-medium" > Login </button> )} 
            {account && ( 
              <button onClick={logout} className="text-sm text-red-600 hover:text-red-800 font-medium" > Logout </button> )}

          {/* Cart */}
          <button className="relative">
            <span className="material-icons text-3xl text-gray-700">
              shopping_cart
            </span>
            <span className="absolute -top-1 -right-1 bg-red-500 text-white text-xs px-1.5 py-0.5 rounded-full">
              3
            </span>
          </button>
        </div>

        <button className="md:hidden">
          <span className="material-icons text-3xl text-gray-700">menu</span>
        </button>
      </div>
    </nav>
  );
}
