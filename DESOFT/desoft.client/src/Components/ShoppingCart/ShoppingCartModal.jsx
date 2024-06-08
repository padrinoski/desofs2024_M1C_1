import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import { fetchShoppingCartData } from './get-shopping-cart-backOffice.jsx';
import './ShoppingCart.css';

function ShoppingCartModal({ modalVisible, toggleModal, userId }) {
    const [shoppingCartItems, setShoppingCartItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await fetchShoppingCartData(userId);
                setShoppingCartItems(data);
            } catch (error) {
                console.error('Error fetching shopping cart data:', error);
            } finally {
            }
        };

        if (modalVisible) {
            fetchData();
        }
    }, [modalVisible, userId]);

    return (
        modalVisible && (
            <div className="shopping-cart-modal" onClick={toggleModal}>
                <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                    <span className="close" onClick={toggleModal}>&times;</span>
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
                            <Link className="checkout-button" to={`PlaceOrder`}>Checkout</Link>
                        </>
                    ) : (
                        <p>No items in the cart</p>
                    )}
                </div>
            </div>
        )
    );
}

export default ShoppingCartModal;
