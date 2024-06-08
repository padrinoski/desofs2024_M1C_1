import React, { useState } from 'react';

const SearchComicBooks = () => {
    const [titleToFilter, setTitleToFilter] = useState('');
    const [authorToFilter, setAuthorToFilter] = useState('');
    const [sortBy, setSortBy] = useState('');
    const [sortingOrder, setSortingOrder] = useState('');
    const [showModal, setShowModal] = useState(false);

    const handleFilter = () => {
        // Handle the filter logic here
    };

    return (
        <div>
            <button onClick={() => setShowModal(!showModal)}>Filter</button>
            {showModal && (
                <div>
                    <label> Title </label>
                    <input type="text" placeholder="Search by Title" value={titleToFilter} onChange={(e) => setTitleToFilter(e.target.value)} />
                    <label> Author </label>
                    <input type="text" placeholder="Search by Author" value={authorToFilter} onChange={(e) => setAuthorToFilter(e.target.value)} />
                    <label> Sort by </label>
                    <select value={sortBy} onChange={(e) => setSortBy(e.target.value)}>
                        <option value="asc">Ascending</option>
                        <option value="desc">Descending</option>
                    </select>
                    <label> Sorting Order</label>
                    <select value={sortingOrder} onChange={(e) => setSortingOrder(e.target.value)}>
                        <option value="price">Price</option>
                        <option value="publishingDate">Publishing Date</option>
                    </select>
                    <div style={{
                        display: 'flex',
                        justifyContent: 'space-between',
                        padding: '10px',
                        backgroundColor: '#f2f2f2',
                        borderRadius: '5px'
                    }}>
                        <button style={{
                            padding: '10px 20px',
                            backgroundColor: '#4CAF50',
                            color: 'white',
                            border: 'none',
                            borderRadius: '5px',
                            cursor: 'pointer'
                        }} onClick={() => {setTitleToFilter(''); setAuthorToFilter(''); setSortBy(''); setSortingOrder('');}}> Clear </button>
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