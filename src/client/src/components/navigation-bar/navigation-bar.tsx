export default function Navbar() {
  return (
    <nav className="w-full bg-white border-b shadow-sm">
      <div className="max-w-7xl mx-auto px-4 py-3 flex items-center justify-between">
        
        {/* Logo */}
        <div className="text-2xl font-bold text-gray-800">
          ShopEase
        </div>

        {/* Desktop Links */}
        <div className="hidden md:flex items-center gap-6 text-gray-700 font-medium">
          <a href="/" className="hover:text-gray-900">Catalog</a>
          <a href="/about" className="hover:text-gray-900">About</a>
          <a href="/contact" className="hover:text-gray-900">Contact</a>
        </div>

        {/* Cart */}
        <button className="relative">
          <span className="material-icons text-3xl text-gray-700">shopping_cart</span>
          <span className="absolute -top-1 -right-1 bg-red-500 text-white text-xs px-1.5 py-0.5 rounded-full">
            3
          </span>
        </button>

        {/* Mobile Menu Button */}
        <button className="md:hidden">
          <span className="material-icons text-3xl text-gray-700">menu</span>
        </button>
      </div>
    </nav>
  );
}