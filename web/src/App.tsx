import { BrowserRouter, Routes, Route } from "react-router-dom"
import { LoginPage } from "./features/authentication/pages/LoginPage";
import { RegisterPage } from "./features/authentication/pages/RegisterPage";
import { HomePage } from "./pages/HomePage";
import { ProtectedRoute } from "./components/ProtectedRoute";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route
                    path="/login"
                    element={<LoginPage />}
                />

                <Route
                    path="/register"
                    element={<RegisterPage />}
                />
                <Route
                    path="/"
                    element={
                      <ProtectedRoute>
                        <HomePage/>
                      </ProtectedRoute>
                    } 
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;