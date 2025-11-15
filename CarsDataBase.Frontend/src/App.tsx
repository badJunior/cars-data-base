import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SellingCarsList from "./SellingCarsList";
import Header from "./components/header";
import { BrowserRouter } from "react-router";
import { Routes } from "react-router";
import { Route } from "react-router";
import GenerateCarsPage from "./generateCarsPage";
const queryClient = new QueryClient();
function App() {
  return (
    <>
      <BrowserRouter>
        <QueryClientProvider client={queryClient}>
          <div className="flex flex-col h-full">
            <Header />
            <div className="size-full bg-[#1a191e] text-gray-200">
              <Routes>
                <Route path="/" element={<SellingCarsList />} />
                <Route path="/generate" element={<GenerateCarsPage />} />
              </Routes>
            </div>
          </div>
        </QueryClientProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
