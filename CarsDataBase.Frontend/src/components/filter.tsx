export default function Filter(props: {
  filterData: FilterData;
  selectedFilter: SelectedFilter;
  onSelectedFilterChanged: (newSelectedFilter: SelectedFilter) => void;
}) {
  return (
    <div className="grid grid-cols-4 gap-4 bg-[#1a191e] text-gray-200 p-4 rounded-xl border border-gray-800">
      <div className="relative">
        <select
          className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer"
          value={props.selectedFilter.make ?? ""}
          onChange={(e) => {
            props.onSelectedFilterChanged({
              ...props.selectedFilter,
              make: e.target.value != "" ? e.target.value : undefined,
            });
          }}
        >
          <option></option>
          {props.filterData.makes.map((make) => (
            <option value={make}>{make}</option>
          ))}
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
        <select
          className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer"
          value={props.selectedFilter.model ?? ""}
          onChange={(e) => {
            props.onSelectedFilterChanged({
              ...props.selectedFilter,
              model: e.target.value != "" ? e.target.value : undefined,
            });
          }}
        >
          <option></option>
          {props.filterData.models.map((model) => (
            <option value={model}>{model}</option>
          ))}
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
        <select
          className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer"
          value={props.selectedFilter.dealer ?? ""}
          onChange={(e) => {
            props.onSelectedFilterChanged({
              ...props.selectedFilter,
              dealer: e.target.value != "" ? e.target.value : undefined,
            });
          }}
        >
          <option></option>
          {props.filterData.dealers.map((dealer) => (
            <option value={dealer}>{dealer}</option>
          ))}
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
        <select
          className="w-full appearance-none bg-[#1a191e] border border-gray-700 text-gray-300 text-sm rounded-md px-4 py-2 pr-8 focus:outline-none focus:ring-2 focus:ring-gray-600 cursor-pointer"
          value={props.selectedFilter.color ?? ""}
          onChange={(e) => {
            props.onSelectedFilterChanged({
              ...props.selectedFilter,
              color: e.target.value != "" ? e.target.value : undefined,
            });
          }}
        >
          <option></option>
          {props.filterData.colors.map((color) => (
            <option value={color}>{color}</option>
          ))}
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
        value={props.selectedFilter.minPrice ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            minPrice: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <input
        type="number"
        placeholder="Max price"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
        value={props.selectedFilter.maxPrice ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            maxPrice: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <input
        type="number"
        placeholder="From year"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
        value={props.selectedFilter.minYear ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            minYear: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <input
        type="number"
        placeholder="To year"
        className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
        value={props.selectedFilter.maxYear ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            maxYear: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
    </div>
  );
}

export type FilterData = {
  makes: string[];
  models: string[];
  colors: string[];
  dealers: string[];
};

export type SelectedFilter = {
  make?: string;
  model?: string;
  color?: string;
  dealer?: string;
  minPrice?: number;
  maxPrice?: number;
  minYear?: number;
  maxYear?: number;
};
