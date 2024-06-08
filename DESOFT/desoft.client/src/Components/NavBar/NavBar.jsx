import './NavBar.css';
import React, { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
import ShoppingCartModal from '../ShoppingCart/ShoppingCartModal.jsx';
import LoginButton from "../../Authentication/Login/Login.tsx"
import { useAuth0 } from '@auth0/auth0-react';
import LogoutButton from "../../Authentication/Logout/Logout.tsx"
import Profile from "../../Profile/Profile.tsx"

function NavBar() {
    const [modalVisible, setModalVisible] = useState(false);

    const { user, isAuthenticated, logout } = useAuth0();

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
                </div>
                <div className="rightPane">
                    {isAuthenticated && <Link id="profileBtn" to="/profile">Profile</Link>}
                    {isAuthenticated && <Link id="customersOrders" to={`CostumersOrders`}>Customers Orders</Link>}
                    {isAuthenticated ? <LogoutButton>Logout</LogoutButton> : <LoginButton>Login</LoginButton>}
                </div>

            </div>
        </>
    );
}

export default NavBar;