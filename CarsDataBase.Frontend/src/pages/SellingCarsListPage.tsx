import { useQuery } from "@tanstack/react-query";
import { httpClient } from "../utils";
import { useState } from "react";
import { Button } from "../components/ui/button";
import Filter, { type SelectedFilter } from "../components/filter";
import {
  createColumnHelper,
  flexRender,
  getCoreRowModel,
  useReactTable,
} from "@tanstack/react-table";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { useNavigate } from "react-router";

export default function SellingCarsListPage() {
  const filterDataQuery = useQuery({
    queryKey: ["filters"],
    queryFn: getFilters,
  });

  const [filter, setFilter] = useState(defaultFilter);
  const query = useQuery({
    queryKey: ["selling-cars", filter],
    queryFn: async () => await getSellingCars(filter),
  });
  return (
    <div className="h-full grid grid-rows-[auto_auto_1fr] gap-2 p-1">
      <Card className="w-full">
        <CardHeader>
          <CardTitle>Available cars</CardTitle>
          <CardDescription>
            Explore every car currently loaded in the system. Use the filters to
            narrow down results
          </CardDescription>
        </CardHeader>
        <CardContent></CardContent>
      </Card>

      <Card className="w-full">
        <CardHeader>
          <CardTitle>Filters</CardTitle>
          <CardDescription>
            Adjust the criteria to find the right vehicles
          </CardDescription>
          <CardAction>
            <Button variant="link" onClick={() => setFilter(defaultFilter)}>
              Reset filters
            </Button>
          </CardAction>
        </CardHeader>
        <CardContent>
          <Filter
            filterData={
              filterDataQuery.data ?? {
                makes: [],
                dealers: [],
                models: [],
                colors: [],
              }
            }
            selectedFilter={filter}
            onSelectedFilterChanged={(newFilter) => {
              console.log(JSON.stringify(newFilter));
              setFilter(newFilter);
            }}
          />
        </CardContent>
      </Card>

      <div className="size-full p-2 rounded-xl bg-card overflow-hidden">
        <div className="size-full overflow-auto">
          {query.isLoading ? (
            <span>Loading...</span>
          ) : query.isError || query.data?.filteredCars == null ? (
            <span>Error</span>
          ) : (
            <SellingCarsTable cars={query.data?.filteredCars} />
          )}
        </div>
      </div>
    </div>
  );
}

async function getSellingCars(filter: SelectedFilter) {
  const result = await httpClient.post<GetSellingFilteredCarsResponse>(
    "/filtered-selled-cars",
    {
      selectedFilter: filter,
    }
  );
  const sellingCars: GetSellingFilteredCarsResponse = await result.data;
  return sellingCars;
}

async function getFilters() {
  const result = await httpClient.get<GetFilterDataResponse>("/filters");
  const filterData: GetFilterDataResponse = await result.data;
  return filterData;
}

const columnHelper = createColumnHelper<SellingCar>();

const columns = [
  columnHelper.accessor((row) => row.car.firm, {
    id: "firm",
    cell: (info) => <i>{info.getValue()}</i>,
    header: () => <span>Manufacturer</span>,
    footer: (info) => info.column.id,
  }),
  columnHelper.accessor((row) => row.car.model, {
    header: "Model",
    cell: (info) => info.renderValue(),
  }),
  columnHelper.accessor((row) => row.car.year, {
    header: "Year",
    cell: (info) => info.renderValue(),
  }),
  columnHelper.accessor((row) => row.car.power, {
    header: "Power",
    cell: (info) => info.renderValue(),
  }),
  columnHelper.accessor((row) => row.dealer.name, {
    header: "Dealer",
    cell: (info) => info.renderValue(),
  }),
  columnHelper.accessor((row) => row.dealer.rating, {
    header: "Rating",
    cell: (info) => info.renderValue(),
  }),

  columnHelper.accessor((row) => row.car.price, {
    header: "Price",
    cell: (info) => info.renderValue(),
  }),
];

function SellingCarsTable(props: { cars: SellingCar[] }) {
  const table = useReactTable({
    data: props.cars,
    columns,
    getCoreRowModel: getCoreRowModel(),
  });

  const navigation = useNavigate();

  return (
    <div className="p-2 size-full">
      <table className="h-auto w-full">
        <thead>
          {table.getHeaderGroups().map((headerGroup) => (
            <tr key={headerGroup.id}>
              {headerGroup.headers.map((header) => (
                <th key={header.id}>
                  {header.isPlaceholder
                    ? null
                    : flexRender(
                        header.column.columnDef.header,
                        header.getContext()
                      )}
                </th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody>
          {table.getRowModel().rows.map((row) => (
            <tr
              key={row.id}
              className="hover:bg-gray-500 cursor-pointer"
              onClick={() => navigation("/selled-cars/" + row.original.id)}
            >
              {row.getVisibleCells().map((cell) => (
                <td key={cell.id}>
                  {flexRender(cell.column.columnDef.cell, cell.getContext())}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

type GetSellingFilteredCarsResponse = { filteredCars: SellingCar[] };

type SellingCar = { id: number; car: Car; dealer: Dealer };

type Car = {
  id: number;
  firm: string;
  model: string;
  year: number;
  power: number;
  color: string;
  price: number;
};

type Dealer = {
  id: number;
  name: string;
  city: string;
  address: string;
  area: string;
  rating: number;
};

const defaultFilter: SelectedFilter = {
  make: undefined,
  model: undefined,
  color: undefined,
  dealer: undefined,
  minPrice: undefined,
  maxPrice: undefined,
  minYear: undefined,
  maxYear: undefined,
};

type GetFilterDataResponse = {
  makes: string[];
  models: string[];
  colors: string[];
  dealers: string[];
};
