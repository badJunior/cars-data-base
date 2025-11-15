import { useQuery } from "@tanstack/react-query";
import { httpClient } from "./utils";
import React, { useState } from "react";
import Button from "./components/button";
import Filter, {
  type FilterData,
  type SelectedFilter,
} from "./components/filter";
import SecondButton from "./components/secondButton";

export default function SellingCarsList() {
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
    <div className="bg-[#1a191e] h-full">
      <div className="grid grid-cols-[1fr] bg-[#1a191e] text-gray-200 px-6 py-4 ">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl">Available cars</h1>
            <span className="text-gray-200">
              Explore every car currently loaded in the system. Use the filters
              to narrow down results
            </span>
          </div>

          <Button
            caption="Generate new listings"
            onClick={() => console.log("Generate clicked")}
          />
        </div>
      </div>

      <div className="flex flex-col bg-[#1a191e] px-6 py-4 gap-2   ">
        <div className="flex flex-col text-gray-200">
          <span className="text-xl">Filters</span>
          <span>Adjust the criteria to find the right vehicles</span>
        </div>
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

        <SecondButton
          caption="Reset filters"
          onClick={() => setFilter(defaultFilter)}
        />
      </div>
      <div className="flex flex-col bg-[#1a191e] text-gray-200 px-6 py-4 ">
        <span className="text-2xl">Results</span>
        <div className="grid grid-cols-3 p-1 bg-[#1a191e] border border-gray-700 rounded-xl">
          {query.data?.filteredCars.map((selledCar) => (
            <React.Fragment key={selledCar.id}>
              <span className="text-gray-200">{selledCar.car.model}</span>
              <span className="text-gray-200">{selledCar.dealer.name}</span>
              <span className="text-gray-200">{selledCar.car.price}</span>
            </React.Fragment>
          ))}
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

type GetSellingCarsResponse = { selledCars: SellingCar[] };

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
