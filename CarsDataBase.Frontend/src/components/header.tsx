import Button from "./button";

export default function Header() {
  return (
    <header className="sticky top-0 z-50 bg-[#1a191e] text-gray-200 flex items-center justify-between px-6 py-3 border-b border-gray-800">
      <nav className="flex items-center space-x-4">
        <Button
          caption="Cars Selling"
          onClick={() => console.log("Generate clicked")}
        />
        <Button
          caption="Generate listings"
          onClick={() => console.log("Generate clicked")}
        />
        <Button
          caption="Browse inventory"
          onClick={() => console.log("Browse clicked")}
        />
      </nav>
    </header>
  );
}
