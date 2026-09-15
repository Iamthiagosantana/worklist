import { useEffect, useState } from "react";
import { getCurrentUser } from "../features/authentication/api/authApi";
import { getToken } from "../lib/auth";

export function HomePage() {
    const [username, setUsername] = useState<string | null>(null);

    useEffect(() => {
        async function loadUser() {
            const token = getToken();

            if (!token) {
                return;
            }

            try {
                const user = await getCurrentUser(token);
                setUsername(user.username);
            } catch {
                console.error("Authentication failed");
            }
        }

        loadUser();
    }, []);

    return (
        <main>
            <h1>
                {username
                    ? `Welcome, ${username}`
                    : "Not authenticated"}
            </h1>
        </main>
    );
}