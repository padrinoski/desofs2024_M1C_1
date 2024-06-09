import './NavBar.css';
import React, { useEffect} from 'react';
import {Link} from "react-router-dom";
import LoginButton from "../../Authentication/Login/Login.tsx";
import LogoutButton from "../../Authentication/Logout/Logout.tsx";
import customUseAuth0 from "../../Authentication/customUseAuth0.jsx";

function NavBar() {

    const { isAuthenticated} = customUseAuth0();

    //user.userId dá o userId
    //user.username dá o username

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
                    {isAuthenticated && <Link id="shoppingCart" to="/ShoppingCart">Shopping Cart</Link>}
                    {isAuthenticated && <Link id="profileBtn" to="/profile">Profile</Link>}
                    {isAuthenticated && <Link id="customersOrders" to={`CostumersOrders`}>Customers Orders</Link>}
                    {isAuthenticated ? <LogoutButton>Logout</LogoutButton> : <LoginButton>Login</LoginButton>}
                </div>

            </div>
        </>
    );
}

export default NavBar;
