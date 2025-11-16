import { Combobox } from "./ui/combobox";
import { Input } from "./ui/input";

export default function Filter(props: {
  filterData: FilterData;
  selectedFilter: SelectedFilter;
  onSelectedFilterChanged: (newSelectedFilter: SelectedFilter) => void;
}) {
  return (
    <div className="grid grid-cols-4 gap-4">
      <Combobox
        value={props.selectedFilter.make ?? ""}
        onValuechanged={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            make: e != "" ? e : undefined,
          });
        }}
        placeholder="Manufacturer"
        items={props.filterData.makes.map((m) => ({ value: m, label: m }))}
      />

      <Combobox
        value={props.selectedFilter.model ?? ""}
        onValuechanged={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            model: e != "" ? e : undefined,
          });
        }}
        placeholder="Manufacturer"
        items={props.filterData.models.map((m) => ({ value: m, label: m }))}
      />

      <Combobox
        value={props.selectedFilter.color ?? ""}
        onValuechanged={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            color: e != "" ? e : undefined,
          });
        }}
        placeholder="Manufacturer"
        items={props.filterData.colors.map((m) => ({ value: m, label: m }))}
      />

      <Combobox
        value={props.selectedFilter.dealer ?? ""}
        onValuechanged={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            dealer: e != "" ? e : undefined,
          });
        }}
        placeholder="Manufacturer"
        items={props.filterData.dealers.map((m) => ({ value: m, label: m }))}
      />

      <Input
        type="number"
        placeholder="Min price"
        value={props.selectedFilter.minPrice ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            minPrice: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <Input
        type="number"
        placeholder="Max price"
        value={props.selectedFilter.maxPrice ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            maxPrice: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <Input
        type="number"
        placeholder="From year"
        value={props.selectedFilter.minYear ?? ""}
        onChange={(e) => {
          props.onSelectedFilterChanged({
            ...props.selectedFilter,
            minYear: e.target.value != "" ? e.target.valueAsNumber : undefined,
          });
        }}
      />
      <Input
        type="number"
        placeholder="To year"
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
