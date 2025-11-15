import { useParams } from "react-router";
import { httpClient } from "./utils";
import { useQuery } from "@tanstack/react-query";

function PropertyRow(props: { caption: string; value: Object }) {
  return (
    <>
      <span className="text-gray-400">{props.caption}</span>{" "}
      <span className="font-bold">{props.value.toString()}</span>
    </>
  );
}

export default function SelledCarPage() {
  const { carId } = useParams();
  if (carId == null) return <span>wrong id</span>;
  const carIdNumber = Number.parseInt(carId);
  const query = useQuery({
    queryKey: ["selling-cars", carId],
    queryFn: async () => await getSellingCar(carId),
  });
  return (
    <div>
      {query.isLoading ? (
        <span>loading...</span>
      ) : query.data == null ? (
        <span>Error...</span>
      ) : (
        <SelledCarCard sellingCar={query.data?.selledCar}></SelledCarCard>
      )}
    </div>
  );
}

async function getSellingCar(carId: string) {
  const result = await httpClient.get<GetSelledCarByIdResponse>(
    `/selled-cars/${carId}`
  );

  return result.data;
}

type GetSelledCarByIdResponse = {
  selledCar: SellingCar;
};

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

function SelledCarCard(props: { sellingCar: SellingCar }) {
  return (
    <div className="flex size-full">
      <div className="grid grid-cols-[auto_auto] gap-1 p-1 m-auto">
        <PropertyRow caption={"Model"} value={props.sellingCar.car.model} />
        <PropertyRow
          caption={"Manufacturer"}
          value={props.sellingCar.car.firm}
        />
        <PropertyRow caption={"Year"} value={props.sellingCar.car.year} />
        <PropertyRow caption={"Price"} value={props.sellingCar.car.price} />
      </div>
    </div>
  );
}
