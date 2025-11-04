import { useQuery } from "@tanstack/react-query";
import { httpClient } from "./utils";
import React from "react";
import Button from "./components/button";
import Input from "./components/input";
import SecondButton from "./components/secondButton";

export default function SellingCarsList() {
  const query = useQuery({
    queryKey: ["selling-cars"],
    queryFn: getSellingCars,
  });
  return (
    <div className="bg-[#1a191e]">
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
        <Input />
        <SecondButton
          caption="Reset filters"
          onClick={() => console.log("Reset filters")}
        />
      </div>
      <div className="flex flex-col bg-[#1a191e] text-gray-200 px-6 py-4 ">
        <span className="text-2xl">Results</span>
        <div className="grid grid-cols-3 p-1 bg-[#1a191e] border border-gray-700 rounded-xl">
          {query.data?.selledCars.map((selledCar) => (
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

async function getSellingCars() {
  const result = await httpClient.get<GetSellingCarsResponse>("/selled-cars");
  const sellingCars: GetSellingCarsResponse = await result.data;
  return sellingCars;
}

type GetSellingCarsResponse = { selledCars: SellingCar[] };

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
