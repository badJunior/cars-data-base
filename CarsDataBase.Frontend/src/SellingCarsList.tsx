import { useQuery } from "@tanstack/react-query";
import { httpClient } from "./utils";
import React from "react";

export default function SellingCarsList() {
  const query = useQuery({
    queryKey: ["selling-cars"],
    queryFn: getSellingCars,
  });
  return (
    <div className="grid grid-cols-3 p-1 bg-amber-600">
      {query.data?.selledCars.map((selledCar) => (
        <React.Fragment key={selledCar.id}>
          <span>{selledCar.car.model}</span>
          <span>{selledCar.dealer.name}</span>
          <span>{selledCar.car.price}</span>
        </React.Fragment>
      ))}
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
