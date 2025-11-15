import { NavLink } from "react-router";
import { Link } from "react-router";

export default function Header() {
  return (
    <header className="sticky top-0 z-50 bg-[#1a191e] text-gray-200 flex items-center justify-between px-6 py-3 border-b border-gray-800">
      <nav className="flex items-center space-x-4">
        <NavLink
          to={"/generate"}
          className={({
            isActive,
          }) => `px-4 py-2 rounded-md bg-[#1a191e] text-white text-sm font-medium hover:bg-gray-700 
       ${isActive ? "underline" : ""}`}
        >
          generate selling
        </NavLink>
        <NavLink
          to={"/"}
          className={({
            isActive,
          }) => `px-4 py-2 rounded-md bg-[#1a191e] text-white text-sm font-medium hover:bg-gray-700 
       ${isActive ? "underline" : ""}`}
        >
          cars selling
        </NavLink>
      </nav>
    </header>
  );
}
