import React, { useState, useEffect } from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';
import './order-history.css';

export default function OrderHistory() {

    const [orders, setOrders] = useState([]);
    const [orderDetails, setOrderDetails] = useState(0);
    const [orderItems, setOrderItems] = useState(Object);
    const [orderDetailsVisible, setOrderDetailsVisible] = useState(false);
    const [hasAccess, setAccessCheck] = useState(false);
    const { user, isAuthenticated, isLoading, getAccessTokenSilently, loginWithRedirect } = useAuth0();

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

    function returnPDF(orderId) {
        //axios.get('http://localhost:5265/api/GenerateInvoice/GenerateInvoiceDocument/'+orderId
        //)
        //.then(response => {
        //    downloadPDF(response.data);
        //})
        //.catch(error => {
        //    console.error(error);
        //});  

     getAccessTokenSilently({
            authorizationParams: {
                audience: `http://${domain}`,
            },
        }).then(accessToken => {

            const url = `http://${domain}/api/GenerateInvoice/GenerateInvoiceDocument/`+orderId
                fetch(url, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,
                    },
                }).then(response => {
                    downloadPDF(response.data);
                }).catch(error => {
                    console.error(error);
                });
                
        }
        ).catch(error => {
            console.error(error);
        });


    }

    function downloadPDF(pdf) {
        const linkSource = `data:application/pdf;base64,${pdf.data}`;
        const downloadLink = document.createElement("a");
        const fileName = "invoice.pdf";
        downloadLink.href = linkSource;
        downloadLink.download = fileName;
        downloadLink.click();}

    useEffect(() => {
        //axios.get('http://localhost:5265/api/PlaceOrder/GetOrdersByUserId/6'
        //)
        //.then(response => {
        //    setOrders(response.data);
        //})
        //.catch(error => {
        //    console.error(error);
        //});     

        const getOrderHistory = async () => {
            const domain = "localhost:5265";

            try {
                const accessToken = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`,
                    },
                })


                console.log(user);

                const url = `http://${domain}/api/PlaceOrder/GetOrdersByUserId/${user.id}`;

                const ordersResponse = await fetch(url, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,
                    },
                });

                const ordersData = await ordersResponse.json();

                setOrders(ordersData);
            } catch (e) {
                console.error(e);
            }

        };
        
        if (user && isAuthenticated) {
            getOrderHistory();
        }

    }, [user, getAccessTokenSilently]);


    return (
        <div className="page">
            <h1 className="title">OrderHistory</h1>
            <table>
                <thead>
                    <tr>
                        <th>Order number</th>
                        <th>Total Price</th>
                        <th>Order Details</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {orders.data?.map(order => (
                        <tr key={order.orderId}>
                            <td>{order.orderId}</td>
                            <td>{order.totalCost}</td>
                            <td><button onClick={toggleViewInfo(order.orderId, order.shoppingCartItems)}>View details</button></td>
                            <td><button onClick={() => returnPDF(order.orderId)}>Download PDF</button></td>
                        </tr>
                    ))}
                    <tr key={1}>
                        <td>1</td>
                        <td>100</td>
                        <td><button onClick={toggleViewInfo(1)}>View details</button></td>
                        <td><button onClick={() => returnPDF(17)}>Download PDF</button></td>  
                    </tr>
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
                                    <th>Quantity</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                            {orderItems.map(orderItem => (
                                <tr key={orderItem.shoppingCartItemId}>
                                    <td>{orderItem.comicBookTitle}</td>
                                    <td>{orderItem.comicBookPrice}</td>
                                    <td>{orderItem.quantity}</td>
                                    <td>{orderItem.comicBookPrice * orderItem.quantity}</td>
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