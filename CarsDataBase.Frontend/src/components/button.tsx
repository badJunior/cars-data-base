import { Button as CnButton } from "@/components/ui/button";

export default function Button(props: {
  caption: string;
  onClick?: () => void;
  className?: string;
  isDisabled?: boolean;
}) {
  return (
    <CnButton disabled={props.isDisabled ?? false} onClick={props.onClick}>
      {props.caption}
    </CnButton>
  );
}
