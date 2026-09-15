const API_URL = "http://localhost:5000";

export async function apiFetch(
    path: string,
    options: RequestInit = {}
) {
    const response = await fetch(`${API_URL}${path}`, {
        ...options,
        headers: {
            "Content-Type": "application/json",
            ...options.headers,
        },
    });

    if (!response.ok) {
        throw new Error(`API request failed: ${response.status}`);
    }

    return response;
}