export default function Button(props: {
  caption: string;
  onClick?: () => void;
  className?: string;
}) {
  return (
    <button
      onClick={props.onClick}
      className={`px-4 py-2 rounded-md bg-[#1a191e] text-white text-sm font-medium hover:bg-gray-700 
      }`}
    >
      {props.caption}
    </button>
  );
}
