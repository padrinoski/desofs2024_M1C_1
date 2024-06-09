import axios from 'axios';

export async function fetchShoppingCartData(userId) {
    try {
        const response = await axios.get(`http://localhost:5265/api/ShoppingCart/GetShoppingCartByUser/${userId}`);

        const items = response.data.data;
        return await Promise.all(items.map(async (item) => {
            const comicBookResponse = await axios.get(`http://localhost:5265/api/ComicBook/GetComicBook/${item.comicBookId}`);
            return {
                ...item,
                comicBookDetails: comicBookResponse.data
            };
        }));
    } catch (error) {
        console.error('Network Error:', error);
        throw new Error('Error fetching shopping cart data');
    }
}
