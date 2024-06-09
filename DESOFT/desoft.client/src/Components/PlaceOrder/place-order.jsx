import React, {useState, useEffect} from 'react';
import axios from 'axios';
import PlaceOrderFrontOffice from './place-order-frontOffice.jsx';

export default function PlaceOrder() {
    const [backOffice, setbackOffice] = useState(false);

    /*    useEffect(() => {
            axios.get('https://localhost:5265/api/Login/IsBackOffice')
                .then(response => {
                    setbackOffice(response.data);
                })
                .catch(() => {
                    setbackOffice(false);
                });
        }, []);*/

    return (
        <PlaceOrderFrontOffice></PlaceOrderFrontOffice>
    );
}
