import './NavBar.css';
import React, {useState, useEffect} from 'react';
import {Link} from "react-router-dom";
import ShoppingCartModal from '../ShoppingCart/ShoppingCartModal.jsx';
import LoginButton from "../../Authentication/Login/Login.tsx";
import LogoutButton from "../../Authentication/Logout/Logout.tsx";
import customUseAuth0 from "../../Authentication/customUseAuth0.jsx";

function NavBar() {
    const [modalVisible, setModalVisible] = useState(false);
    const {userInfo, isAuthenticated, logout} = customUseAuth0();

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

    const toggleModal = () => {
        setModalVisible(prevState => !prevState);
    };

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
                    {isAuthenticated && <a href="#" onClick={toggleModal}>Shopping Cart</a>}
                    {isAuthenticated && <ShoppingCartModal modalVisible={modalVisible} toggleModal={toggleModal} userId={userInfo?.userId} />}
                    {isAuthenticated && <Link id="profileBtn" to="/profile">Profile</Link>}
                    {isAuthenticated && <Link id="customersOrders" to={`CostumersOrders`}>Customers Orders</Link>}
                    {isAuthenticated ? <LogoutButton>Logout</LogoutButton> : <LoginButton>Login</LoginButton>}
                </div>

            </div>
        </>
    );
}

export default NavBar;
