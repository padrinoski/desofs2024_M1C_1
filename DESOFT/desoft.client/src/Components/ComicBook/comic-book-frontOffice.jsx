import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAuth0 } from '@auth0/auth0-react';
import AddComicBookBtn from './add-comicBook';
import EditComicBookDialog from './edit-comic-dialog';
import FilterComicBooks from './search-comic-books';
import ReactDom from 'react-dom';

export default function ComicBookFrontOffice() {
    const { getAccessTokenSilently } = useAuth0();
    const [comics, setComics] = useState([]);
    const domain = `localhost:5265`;

    useEffect(() => {
        const getComics = async () => {
            try {
                const accessToken = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`,
                    },
                });
                
                const url = `http://${domain}/api/ComicBook/GetCatalog`;

                const catalogResponse = await fetch(url, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,

                    },
                });
                

                const {data} =  await catalogResponse.json();
                
                console.log(JSON.stringify(data));

                if(data != null){
                    setComics(data);
                }

            } catch (error) {
                console.error(error);
            }
        };
        getComics();
    }, [getAccessTokenSilently]);

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
                    {comics.map(comic => (
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
