import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './order-history.css';

export default function OrderHistory() {

    const [orders, setOrders] = useState([]);
    const [orderDetails, setOrderDetails] = useState(0);
    const [orderDetailsVisible, setOrderDetailsVisible] = useState(false);

    const toggleViewInfo = (orderId) => {
        return () => {
            setOrderDetails(orderId)
            if(orderId !== 0) {
                setOrderDetailsVisible(true);
            }else {
                setOrderDetailsVisible(false);
            }
        }
    }

    function downloadPDF(pdf) {
        const linkSource = `data:application/pdf;base64,${pdf}`;
        const downloadLink = document.createElement("a");
        const fileName = "file.pdf";
    
        downloadLink.href = linkSource;
        downloadLink.download = fileName;
        downloadLink.click();
    }

    useEffect(() => {
        axios.get('https://localhost:5265/api/PlaceOrder/GetOrdersByUserId/6'
        )
        .then(response => {
            setOrders(response.data);
        })
        .catch(error => {
            console.error(error);
        });        

    }, []);


    return (
        <div className="page">
            <h1 className="title">OrderHistory</h1>
            <table>
                <thead>
                    <tr>
                        <th>Order number</th>
                        <th>Total Price</th>
                        <th>Order Details</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.data?.map(order => (
                        <tr key={order.orderId}>
                            <td>{order.orderId}</td>
                            <td>{comic.totalCost}</td>
                        </tr>
                    ))}
                    <tr key={1}>
                        <td>1</td>
                        <td>100</td>
                        <td><button onClick={toggleViewInfo(1)}>View details</button></td>
                    </tr>
                </tbody>
            </table>

            {orderDetailsVisible ? (
  
            <div className="modal">
                    <div className="overlay"></div>
                    <div className="modal-content">
                        <button className='close-modal' onClick={toggleViewInfo(0)}>Close</button>
                        <h2>Order number: {orderDetails}</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Comic Book</th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Comic Book 1</td>
                                    <td>10</td>
                                </tr>
                                <tr>
                                    <td>Comic Book 2</td>
                                    <td>20</td>
                                </tr>
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