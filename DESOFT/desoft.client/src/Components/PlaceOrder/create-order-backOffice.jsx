import axios from 'axios';

export async function createOrderBackOffice(shoppingCartId, address, paymentMethod) {
    try {
        const order = {
            ShoppingCartId: shoppingCartId,
            Address: address,
            PaymentMethod: paymentMethod
        };
        const response = await axios.post('http://localhost:5265/api/PlaceOrder/CreateOrder', order);
        console.log('Order created successfully:', response.data);
    } catch (error) {
        console.error(error);
        throw new Error('Error fetching shopping cart data');
    }
}
