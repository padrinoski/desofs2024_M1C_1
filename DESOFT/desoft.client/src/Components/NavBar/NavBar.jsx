import './NavBar.css';
import React, { useEffect } from 'react';
import { Link } from "react-router-dom";
import LoginButton from "../../Authentication/Login/Login.tsx"
import { useAuth0 } from '@auth0/auth0-react';
import LogoutButton from "../../Authentication/Logout/Logout.tsx"
import Profile from "../../Profile/Profile.tsx"

function NavBar() {

    const {user, isAuthenticated, logout } = useAuth0();

    useEffect(() => {
        const script = document.createElement('script');

        script.src = "../../src/Components/NavBar/navbar.js";
        script.defer = true;

        document.body.appendChild(script);

        return () => {
            document.body.removeChild(script);
        }
    }, []);

    return (
        <>
            <div className="topnav">
                <div className="leftPane">
                    <Link id="homeBtn" to={`/`}>Home</Link>
                    <Link id="comicBooksBtn" to={`ComicBooks`}>ComicBooks</Link>
                    <Link id="orderHistoryBtn" to={`OrderHistory`}>Order History</Link>
                    <a href="#">Contact</a>
                    <a href="#">About</a>
                    {isAuthenticated && <Link id="profileBtn" to="/profile">Profile</Link>}
                </div>
                <div className="rightPane">
                    {isAuthenticated ? <LogoutButton>Logout</LogoutButton> : <LoginButton>Login</LoginButton>}
                </div>
            </div> 
        </>
  );
}

export default NavBar;