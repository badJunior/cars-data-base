import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SellingCarsList from "./SellingCarsList";

const queryClient = new QueryClient();
function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <SellingCarsList />
      </QueryClientProvider>
    </>
  );
}

export default App;
