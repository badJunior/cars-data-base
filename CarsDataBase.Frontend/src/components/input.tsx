export default function Input() {
  return (
    <div className="grid grid-cols-4 gap-4 bg-[#1a191e] text-gray-200 p-4 rounded-xl border border-gray-800">
      <div className="relative">
        <select className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer">
          <option>All makes</option>
          <option>Audi</option>
          <option>BMW</option>
          <option>Mercedes</option>
        </select>
        <svg
          className="absolute right-3 top-1/2 -translate-y-1/2 pointer-events-none"
          width="16"
          height="16"
          fill="none"
          stroke="gray"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <path d="M4 6l4 4 4-4" />
        </svg>
      </div>

      <div className="relative">
        <select className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer">
          <option>All models</option>
          <option>Q5</option>
          <option>X5</option>
          <option>C-Class</option>
        </select>
        <svg
          className="absolute right-3 top-1/2 -translate-y-1/2 pointer-events-none"
          width="16"
          height="16"
          fill="none"
          stroke="gray"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <path d="M4 6l4 4 4-4" />
        </svg>
      </div>

      <div className="relative">
        <select className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer">
          <option>All colors</option>
          <option>Black</option>
          <option>White</option>
          <option>Red</option>
        </select>
        <svg
          className="absolute right-3 top-1/2 -translate-y-1/2 pointer-events-none"
          width="16"
          height="16"
          fill="none"
          stroke="gray"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <path d="M4 6l4 4 4-4" />
        </svg>
      </div>

      <div className="relative">
        <select className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer">
          <option>All dealers</option>
          <option>AutoWorld</option>
          <option>CarShop</option>
        </select>
        <svg
          className="absolute right-3 top-1/2 -translate-y-1/2 pointer-events-none"
          width="16"
          height="16"
          fill="none"
          stroke="gray"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <path d="M4 6l4 4 4-4" />
        </svg>
      </div>

      <input
        type="number"
        placeholder="Min price"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
      />
      <input
        type="number"
        placeholder="Max price"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
      />
      <input
        type="number"
        placeholder="From year"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
      />
      <input
        type="number"
        placeholder="To year"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
      />
    </div>
  );
}
