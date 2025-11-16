import { useNavigate, useParams } from "react-router";
import { useQuery } from "@tanstack/react-query";
import { httpClient } from "../utils";
import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardAction,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

function PropertyRow(props: { caption: string; value: Object }) {
  return (
    <>
      <Label>{props.caption}</Label>
      <Input value={props.value.toString()} />
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
    <div className="flex size-full">
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
  const navigation = useNavigate();
  return (
    <Card className="size-auto m-auto">
      <CardHeader>
        <CardTitle>{props.sellingCar.car.model}</CardTitle>
        <CardDescription>{props.sellingCar.car.firm}</CardDescription>
        <CardAction>
          <Button onClick={() => navigation(-1)} variant={"link"}>
            Back
          </Button>
        </CardAction>
      </CardHeader>
      <CardContent>
        <div className="flex size-auto">
          <div className="grid grid-cols-[auto_auto] gap-2 p-1 m-auto">
            <PropertyRow caption={"Model"} value={props.sellingCar.car.model} />
            <PropertyRow
              caption={"Manufacturer"}
              value={props.sellingCar.car.firm}
            />
            <PropertyRow caption={"Year"} value={props.sellingCar.car.year} />
            <PropertyRow caption={"Price"} value={props.sellingCar.car.price} />
          </div>
        </div>
      </CardContent>
      <CardFooter>
        <p className="text-right w-full">{props.sellingCar.car.price}</p>
      </CardFooter>
    </Card>
  );
}
