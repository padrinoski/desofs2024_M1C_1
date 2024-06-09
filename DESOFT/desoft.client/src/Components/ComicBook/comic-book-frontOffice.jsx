import React, { useState, useEffect } from 'react';
import axios from 'axios';
import FilterComicBooks from './search-comic-books';
export default function ComicBookFrontOffice() {

    const [comics, setComics] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7242/api/ComicBook/GetCatalog'
        )
        .then(response => {
            setComics(response.data);
        })
        .catch(error => {
            console.error(error);
        });        

    }, []);

    return (
        <div className="page">
            <h1 className="title">Comic Books</h1>
            <FilterComicBooks></FilterComicBooks>

            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Author</th>
                        <th>Edition</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {comics.data?.map(comic => (
                        <tr key={comic.comicBookId}>
                            <td>{comic.title}</td>
                            <td>{comic.description}</td>
                            <td>{comic.author}</td>
                            <td>{comic.version}</td>
                            <td>{comic.price}&euro;</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
