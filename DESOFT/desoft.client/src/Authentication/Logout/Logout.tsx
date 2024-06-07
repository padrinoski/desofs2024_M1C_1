import React from "react";
import { useAuth0, LogoutOptions } from "@auth0/auth0-react";


const LogoutButton = () => {
        const { logout } = useAuth0();
    
        return <a href="#" onClick={() => logout({ returnTo: window.location.origin } as LogoutOptions)}>Log Out</a>;
    };

export default LogoutButton;