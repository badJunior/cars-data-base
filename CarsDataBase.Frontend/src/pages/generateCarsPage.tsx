import { useState } from "react";
import { useMutation } from "@tanstack/react-query";
import { httpClient } from "../utils";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

export default function GenerateCarsPage() {
  const [carsCount, setCarsCount] = useState(50);
  const mutation = useMutation({ mutationFn: generateCars });
  return (
    <div className="w-full h-full flex">
      <Card className="size-auto m-auto">
        <CardHeader>
          <CardTitle>Generation</CardTitle>
          <CardDescription>Regenerating cars to sell</CardDescription>
        </CardHeader>
        <CardContent>
          <Label htmlFor="carsCount">Cars count</Label>
          <Input
            id="carsCount"
            value={carsCount}
            type="number"
            placeholder="Cars count"
            onChange={(e) => setCarsCount(e.target.valueAsNumber)}
          />
        </CardContent>
        <CardFooter>
          <Button
            className="w-full"
            onClick={() => mutation.mutate(carsCount)}
            disabled={mutation.isPending}
          >
            Generate
          </Button>
        </CardFooter>
      </Card>
    </div>
  );
}
async function generateCars(carsCount: number) {
  await httpClient.post("/selled-cars", {
    carsCount: carsCount,
  });
}
