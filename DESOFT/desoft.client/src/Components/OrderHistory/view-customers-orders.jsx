import React, { useState, useEffect } from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';
import './order-history.css';

export default function viewCustomersOrders() {

    const [orders, setOrders] = useState([]);
    const [orderDetails, setOrderDetails] = useState(0);
    const [orderItems, setOrderItems] = useState(Object);
    const [orderDetailsVisible, setOrderDetailsVisible] = useState(false);
    const {user, isAuthenticated, isLoading, getAccessTokenSilently} = useAuth0();

    useEffect(() => {
        const getOrders = async () => {
            const domain = "localhost:5265";
            
            try{
                const accessToken = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`,
                        scope: "read:customer_orders",
                        prompt: 'consent',
                    },
                })
    
                const ordersUrl = `http://${domain}/api/PlaceOrder/GetallOrders`;
    
                const ordersResponse = await fetch(ordersUrl, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,
                    },
                });
    
                const ordersData =  await ordersResponse.json();
    
                setOrders(ordersData);
    
            } catch(e){
                console.error(e);
            }
        };
        if (user && isAuthenticated) {
            getOrders();
        }
    
    }, [user, getAccessTokenSilently]);

    const toggleViewInfo = (orderId, orderI) => {
        return () => {
            setOrderDetails(orderId)
            setOrderItems(orderI)
            if(orderId !== 0) {
                setOrderDetailsVisible(true);
            }else {
                setOrderDetailsVisible(false);
            }
        }
    }

    return (
        <div className="page">
            <h1 className="title">View Customers Orders</h1>
            <table>
                <thead>
                    <tr>
                        <th>Order number</th>
                        <th>Total Price</th>
                        <th>Submitted Date</th>
                        <th>Payment Method</th>
                        <th>Order Details</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {orders.data?.map(order => (
                        <tr key={order.orderId}>
                            <td>{order.orderId}</td>
                            <td>{order.totalCost}</td>
                            <td>{order.submittedDate}</td>
                            <td>{order.paymentMethod}</td>
                            <td><button onClick={toggleViewInfo(order.orderId, order.shoppingCartItems)}>View details</button></td>
                        
                        </tr>
                    ))}
                </tbody>
            </table>

            {orderDetailsVisible ? (
  
            <div className="modal">
                    <div className="overlay"></div>
                    <div className="modal-content">
                        <button className='close-modal' onClick={toggleViewInfo(0, null)}>Close</button>
                        <h2>Order number: {orderDetails}</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Comic Book</th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>
                            {orderItems.map(orderItem => (
                                <tr key={orderItem.shoppingCartItemId}>
                                    <td>{orderItem.comicBookTitle}</td>
                                    <td>{orderItem.comicBookPrice}</td>
                                </tr>
                            ))}
                            </tbody>
                        </table>
                    </div>
            </div>

                ) : (
                    <div></div>
                )}

        </div>

    );

}