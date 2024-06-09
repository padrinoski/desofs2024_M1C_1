import React, { useState } from 'react';
import { useAuth0 } from '@auth0/auth0-react';


export default function SearchComicBooks() {
    const [titleToFilter, setTitleToFilter] = useState('');
    const [authorToFilter, setAuthorToFilter] = useState('');
    const [sortBy, setSortBy] = useState('');
    const [sortingOrder, setSortingOrder] = useState('');
    const [showModal, setShowModal] = useState(false);
    const [filteredCatalogToResult, setFilteredCatalog] = useState([]);

    const sanitizeInput = (input) => {
        const div = document.createElement('div');
        div.textContent = input;
        return div.innerHTML;
    };

    const handleFilter = async () => {
        const sanitizedTitle = sanitizeInput(titleToFilter);
        const sanitizedAuthor = sanitizeInput(authorToFilter);

        try {
            const accessToken = await getAccessTokenSilently({
                authorizationParams: {
                    audience: `http://${domain}`,
                },
            })

            const filterUrl = `http://${domain}/api/ComicBook/SearchComicBooks?author=${sanitizedAuthor}&title=${sanitizedTitle}&sortBy=${sortBy}&sortOrder=${sortingOrder}`;

            const filterResponse = await fetch(filterUrl, {
                headers: {
                    Authorization: `Bearer ${accessToken}`,
                },
            });

            const filteredCatalog = await filterResponse.json();
            console.log(filteredCatalog);

            setFilteredCatalog(filteredCatalog);
        } catch (e) {
            console.error(e);
        }


    };

    return (
        <div>
            <button style={{
                padding: '10px 20px',
                backgroundColor: '#008CBA',
                color: 'white',
                border: 'none',
                borderRadius: '5px',
                cursor: 'pointer',
                marginBottom: '10px'
            }} onClick={() => setShowModal(!showModal)}>Filters</button>
            {showModal && (
                <div>
                    <div style={{
                        justifyContent: 'space-between',
                        padding: '10px',
                        backgroundColor: '#f2f2f2',
                        borderRadius: '5px',
                        marginBottom: '10px'
                    }}>
                        <div style={{ marginBottom: '10px' }}>
                            <label style={{ marginRight: '10px' }}> Title </label>
                            <input style={{ padding: '5px' }} type="text" placeholder="Search by Title" value={titleToFilter} onChange={(e) => setTitleToFilter(e.target.value)} />
                        </div>
                        <div style={{ marginBottom: '10px' }}>
                            <label style={{ marginRight: '10px' }}> Author </label>
                            <input style={{ padding: '5px' }} type="text" placeholder="Search by Author" value={authorToFilter} onChange={(e) => setAuthorToFilter(e.target.value)} />
                        </div>
                        <div style={{ marginBottom: '10px' }}>
                            <label style={{ marginRight: '10px' }}> Sort by </label>
                            <select style={{ padding: '5px' }} value={sortBy} onChange={(e) => setSortBy(e.target.value)}>
                                <option value="">None</option>
                                <option value="asc">Ascending</option>
                                <option value="desc">Descending</option>
                            </select>
                        </div>
                        <div style={{ marginBottom: '10px' }}>
                            <label style={{ marginRight: '10px' }}> Sorting Order</label>
                            <select style={{ padding: '5px' }} value={sortingOrder} onChange={(e) => setSortingOrder(e.target.value)}>
                                <option value="">None</option>
                                <option value="price">Price</option>
                                <option value="publishingDate">Publishing Date</option>
                            </select>
                        </div>
                    </div>
                    <div style={{
                        display: 'flex',
                        justifyContent: 'space-between',
                        padding: '10px',
                        backgroundColor: '#f2f2f2',
                        borderRadius: '5px',
                        marginBottom: '10px'
                    }}>
                        <button style={{
                            padding: '10px 20px',
                            backgroundColor: '#4CAF50',
                            color: 'white',
                            border: 'none',
                            borderRadius: '5px',
                            cursor: 'pointer'
                        }} onClick={() => { setTitleToFilter(''); setAuthorToFilter(''); setSortBy(''); setSortingOrder(''); }}> Clear Filters </button>
                        <button style={{
                            padding: '10px 20px',
                            backgroundColor: '#AA4A44',
                            color: 'white',
                            border: 'none',
                            borderRadius: '5px',
                            cursor: 'pointer'
                        }} onClick={() => { setShowModal(false); }}> Close </button>
                        <button style={{
                            padding: '10px 20px',
                            backgroundColor: '#008CBA',
                            color: 'white',
                            border: 'none',
                            borderRadius: '5px',
                            cursor: 'pointer'
                        }} onClick={handleFilter}> Filter </button>
                    </div>
                </div>
            )}
        </div>
    );
};