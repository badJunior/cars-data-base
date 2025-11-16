import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SellingCarsList from "./pages/SellingCarsListPage";
import Header from "./components/header";
import { BrowserRouter } from "react-router";
import { Routes } from "react-router";
import { Route } from "react-router";
import GenerateCarsPage from "./pages/generateCarsPage";
import SelledCarPage from "./pages/selledCarPage";
const queryClient = new QueryClient();
function App() {
  return (
    <>
      <BrowserRouter>
        <QueryClientProvider client={queryClient}>
          <div className="flex flex-col h-full">
            <Header />
            <div className="size-full bg-background text-primary p-1">
              <Routes>
                <Route path="/" element={<SellingCarsList />} />
                <Route path="/generate" element={<GenerateCarsPage />} />
                <Route
                  path="/selled-cars/:carId"
                  element={<SelledCarPage />}
                ></Route>
              </Routes>
            </div>
          </div>
        </QueryClientProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
