import React, { useState, useEffect } from 'react';
import { fetchShoppingCartData } from '../ShoppingCart/get-shopping-cart-backOffice.jsx';
import { createOrderBackOffice } from './create-order-backOffice.jsx';
import './PlaceOrder.css';

export default function PlaceOrderFrontOffice({ userId }) {
    const [address, setAddress] = useState('');
    const [paymentMethod, setPaymentMethod] = useState('');
    const [cartData, setCartData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [formError, setFormError] = useState('');

    useEffect(() => {
        async function getShoppingCartData() {
            try {
                const data = await fetchShoppingCartData(userId);
                setCartData(data);
                setLoading(false);
            } catch (error) {
                setError(error.message);
                setLoading(false);
            }
        }

        getShoppingCartData();
    }, [userId]);

    const handlePlaceOrder = async (e) => {
        e.preventDefault();
        if (!address) {
            setFormError('Address is required');
            return;
        }
        if (!paymentMethod) {
            setFormError('Please select a valid payment method');
            return;
        }

        try {
            const shoppingCartId = cartData[0]?.shoppingCartId; // Assuming all items have the same shoppingCartId
            await createOrderBackOffice(shoppingCartId, address, paymentMethod);
            setFormError(''); // Clear form error on successful submission
            console.log('Order placed successfully');
        } catch (error) {
            setFormError('Error placing order');
            console.error(error);
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div className="page">
            <h1 className="title">Place Order</h1>
            <form onSubmit={handlePlaceOrder}>
                <table>
                    <thead>
                    <tr>
                        <th>Title</th>
                        <th>Quantity</th>
                        <th>Price</th>
                    </tr>
                    </thead>
                    <tbody>
                    {cartData?.map(item => (
                        <tr key={item.comicBookDetails.data.comicBookId}>
                            <td>{item.comicBookDetails.data.title}</td>
                            <td>{item.quantity}</td>
                            <td>{item.comicBookDetails.data.price}€</td>
                        </tr>
                    ))}
                    </tbody>
                </table>
                <div>
                    <label htmlFor="address">Address:</label>
                    <input
                        type="text"
                        id="address"
                        value={address}
                        onChange={(e) => setAddress(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="paymentMethod">Payment Method:</label>
                    <select
                        id="paymentMethod"
                        value={paymentMethod}
                        onChange={(e) => setPaymentMethod(e.target.value)}
                        required
                    >
                        <option value="">Select Payment Method</option>
                        <option value="creditCard">Credit Card</option>
                        <option value="paypal">PayPal</option>
                        <option value="bankTransfer">Bank Transfer</option>
                    </select>
                </div>
                {formError && <div className="form-error">{formError}</div>}
                <button type="submit">Place Order</button>
            </form>
        </div>
    );
}
