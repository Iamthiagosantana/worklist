import { useState } from "react";
import { register } from "../api/authApi";
import { setToken } from "../../../lib/auth";

export function RegisterForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const [error, setError] = useState<string | null>(null);
    const [loading, setLoading] = useState(false);

    async function handleSubmit(
        event: React.SubmitEvent<HTMLFormElement>
    ) {
        event.preventDefault();

        setError(null);
        setLoading(true);

        try {
            const result = await register({
                username,
                password
            });

            setToken(result.token);

            console.log("Registered");
        } catch {
            setError("Could not create account.");
        } finally {
            setLoading(false);
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <h1>Create account</h1>

            <label>
                Username
                <input
                    value={username}
                    onChange={(event) =>
                        setUsername(event.target.value)
                    }
                />
            </label>

            <label>
                Password
                <input
                    type="password"
                    value={password}
                    onChange={(event) =>
                        setPassword(event.target.value)
                    }
                />
            </label>

            {error && <p>{error}</p>}

            <button type="submit" disabled={loading}>
                {loading ? "Creating account..." : "Register"}
            </button>
        </form>
    );
}