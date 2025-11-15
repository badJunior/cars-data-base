import { useState } from "react";
import Button from "./components/button";
import { useMutation } from "@tanstack/react-query";
import { httpClient } from "./utils";

export default function GenerateCarsPage() {
  const [carsCount, setCarsCount] = useState(50);
  const mutation = useMutation({ mutationFn: generateCars });
  return (
    <div className="w-full h-full flex">
      <div className="flex flex-col gap-1 p-1 m-auto size-auto ">
        <span>Regenerating cars To Sell</span>
        <input
          value={carsCount}
          type="number"
          placeholder="Cars count"
          className="bg-[#1a191e] border border-gray-700 text-gray-300 placeholder-gray-500 text-sm rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-gray-600"
          onChange={(e) => setCarsCount(e.target.valueAsNumber)}
        />

        <Button
          caption={"Generate"}
          onClick={() => mutation.mutate(carsCount)}
        ></Button>
      </div>
    </div>
  );
}
async function generateCars(carsCount: number) {
  const result = await httpClient.post("/selled-cars", {
    carsCount: carsCount,
  });
}
