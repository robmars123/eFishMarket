import { useAuth } from "../../auth/useAuth";
import AccountMenu from "./user-account-menu/user-account-menu";

export default function Navbar() {
  const { account, login } = useAuth();

  return (
    <nav className="w-full bg-white border-b shadow-sm">
      <div className="max-w-7xl mx-auto px-4 py-3 flex items-center justify-between">
        
        <div className="text-2xl font-bold text-gray-800">
          eFishMarket
        </div>

        <div className="hidden md:flex items-center gap-6 text-gray-700 font-medium">
          <a href="/" className="hover:text-gray-900">Catalog</a>
          <a href="/about" className="hover:text-gray-900">About</a>
          <a href="/contact" className="hover:text-gray-900">Contact</a>
        </div>

        <div className="flex items-center gap-4">
          {/* Only show if logged in */}
          {!account && ( 
            <button onClick={login} className="text-sm text-blue-600 hover:text-blue-800 font-medium" > Login </button> )} 
          <button className="">
            <span className="material-icons text-gray-700">
              <AccountMenu />
            </span>
          </button>

          {/* Cart */}
          <button className="relative">
            <span className="material-icons text-gray-700">
              Cart
            </span>
            <span className="absolute -top-1 -right-1 bg-red-500 text-white text-xs px-1.5 py-0.5 rounded-full">
              3
            </span>
          </button>
        </div>
      </div>
    </nav>
  );
}
