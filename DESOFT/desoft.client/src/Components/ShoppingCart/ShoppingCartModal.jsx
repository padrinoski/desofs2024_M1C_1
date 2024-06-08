import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import { fetchShoppingCartData } from './get-shopping-cart-backOffice.jsx';
import '../NavBar/NavBar.css';

function ShoppingCartModal({ modalVisible, toggleModal }) {
    const [shoppingCartItems, setShoppingCartItems] = useState([]);
    const [loading, setLoading] = useState(false);
    const userId = 6;
    let shoppingCart;

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                const data = await fetchShoppingCartData(userId);
                shoppingCart = data[0].shoppingCartId;
                setShoppingCartItems(data);
            } catch (error) {
                console.error('Error fetching shopping cart data:', error);
            } finally {
                setLoading(false);
            }
        };

        if (modalVisible) {
            fetchData();
        }
    }, [modalVisible]);

    return (
        modalVisible && (
            <div className="modal" style={{ display: modalVisible ? 'block' : 'none' }} onClick={toggleModal}>
                <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                    <span className="close" onClick={toggleModal}>&times;</span>
                    <h2>Your Shopping Cart</h2>
                    {loading ? (
                        <p>Loading...</p>
                    ) : shoppingCartItems.length > 0 ? (
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
