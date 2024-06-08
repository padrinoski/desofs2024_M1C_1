import React, {useEffect, useState} from 'react';
import {Link} from "react-router-dom";
import {fetchShoppingCartData} from './get-shopping-cart-backOffice.jsx';
import './ShoppingCart.css';
import customUseAuth0 from "../../Authentication/customUseAuth0.jsx";

function ShoppingCart() {
    const [shoppingCartItems, setShoppingCartItems] = useState([]);
    const {userInfo, isAuthenticated, logout} = customUseAuth0();
    const userId = userInfo?.userId;
    useEffect(() => {
        const fetchData = async () => {
            try {
                if (isAuthenticated && userId !== undefined) {
                    const data = await fetchShoppingCartData(userId);
                    setShoppingCartItems(data);
                }
            } catch (error) {
                console.error('Error fetching shopping cart data:', error);
            } finally {
            }
        };
        fetchData();

    }, [userId]);

    return (
        <div className="modal">
            <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                <h2>Your Shopping Cart</h2>
                {shoppingCartItems.length > 0 ? (
                    <>
                        <table className="cart-table">
                            <thead>
                            <tr>
                                <th>Title</th>
                                <th>Quantity</th>
                            </tr>
                            </thead>
                            <tbody>
                            {shoppingCartItems.map((item, index) => (
                                <tr key={index}>
                                    <td>{item.comicBookDetails.data.title}</td>
                                    <td>{item.quantity}</td>
                                </tr>
                            ))}
                            <tr>&nbsp;</tr>
                            </tbody>
                        </table>
                        <Link className="checkout-button" to={`/PlaceOrder`}>Checkout</Link>
                    </>
                ) : (
                    <p>No items in the cart</p>
                )}
            </div>
        </div>

    );
}

export default ShoppingCart;
