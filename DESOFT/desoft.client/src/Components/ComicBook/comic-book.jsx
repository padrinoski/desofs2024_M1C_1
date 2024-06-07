import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ComicBookBackOffice from './comic-book-backOffice';
import ComicBookFrontOffice from './comic-book-frontOffice';
export default function ComicBook() {

    const [backOffice, setbackOffice] = useState(false);

    useEffect(() => {
        axios.get('https://localhost:7242/api/Login/IsBackOffice'
        )
        .then(response => {
            setbackOffice(response.data);
        })
        .catch(() => {
            setbackOffice(false);
        });

    }, []);

    if (backOffice) {
        return (
            <ComicBookBackOffice></ComicBookBackOffice>
        );
    } else {
        return (
            <ComicBookFrontOffice></ComicBookFrontOffice>
        );
    }

    
}
