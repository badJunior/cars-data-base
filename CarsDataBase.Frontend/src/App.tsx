import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SellingCarsList from "./SellingCarsList";
import Header from "./components/header";

const queryClient = new QueryClient();
function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <div className="flex flex-col ">
          <Header />
          <SellingCarsList />
        </div>
      </QueryClientProvider>
    </>
  );
}

export default App;
