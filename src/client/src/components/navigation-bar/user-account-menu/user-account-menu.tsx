import { useState } from "react";
import { useAuth } from "../../../auth/useAuth";
import { useUserProfile } from "../../authentication/useUserProfile";
//import { useUserProfile } from "../authentication/useUserProfile";

export default function AccountMenu() {
  const { account, logout } = useAuth();
  const { displayName } = useUserProfile();
  const [open, setOpen] = useState(false);

  if (!account) return null; // no menu if not logged in

  const initials = displayName ? displayName.split(" ")
                                            .map((n) => n[0])
                                            .join("")
                                            .toUpperCase()
                               : "U";

  return (
    <div className="relative">
      {/* Avatar + Name */}
      <button
        onClick={() => setOpen((prev) => !prev)}
        className="flex items-center gap-2 px-3 py-2 rounded hover:bg-gray-100"
      >
        <div className="w-8 h-8 bg-gray-700 text-white rounded-full flex items-center justify-center font-semibold">
          {initials}
        </div>
        <span className="text-gray-800 font-medium">{displayName}</span>
      </button>

      {/* Dropdown */}
      {open && (
        <div className="absolute right-0 mt-2 w-48 bg-white border rounded shadow-lg py-2 z-50">
          <a href="/profile" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Profile</a>
          <a href="/orders" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Orders</a>
          <a href="/settings" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">Settings</a>

          {/* Admin Panel — only if user has Admin role */}
          {/* {roles?.includes("Admin") && (
            <a
              href="/admin"
              className="block px-4 py-2 text-gray-700 hover:bg-gray-100 font-semibold text-blue-700"
            >
              Admin Panel
            </a>
          )} */}

          {account && ( 
              <button onClick={logout} className="text-sm text-red-600 hover:text-red-800 font-medium" > Logout </button> )}
        </div>
      )}
    </div>
  );
}
