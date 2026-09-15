import { apiFetch } from "../../../lib/api";
import type {
    RegisterRequest,
    LoginRequest,
    AuthResponse,
    CurrentUser,
} from "../types/auth";

export async function register(
    request: RegisterRequest
): Promise<AuthResponse> {
    const response = await apiFetch("/api/auth/register", {
        method: "POST",
        body: JSON.stringify(request),
    });

    return response.json();
}

export async function login(
    request: LoginRequest
): Promise<AuthResponse> {
    const response = await apiFetch("/api/auth/login", {
        method: "POST",
        body: JSON.stringify(request),
    });

    return response.json();
}

export async function getCurrentUser(
    token: string
): Promise<CurrentUser> {
    const response = await apiFetch("/api/auth/me", {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });

    return response.json();
}