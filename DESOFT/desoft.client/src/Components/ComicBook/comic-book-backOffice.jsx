import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAuth0 } from '@auth0/auth0-react';
import AddComicBookBtn from './add-comicBook';
import EditComicBookDialog from './edit-comic-dialog';
import FilterComicBooks from './search-comic-books';
import ReactDom from 'react-dom';

export default function ComicBookBackOffice() {
    const { getAccessTokenSilently } = useAuth0();
    const [comics, setComics] = useState([]);
    const domain = `localhost:5265`;

    const handleFilter = ({ data: newFilteredCatalog }) => {
        setComics(Array.isArray(newFilteredCatalog) ? newFilteredCatalog : []);
    };


    const [isDialogOpen, setIsDialogOpen] = useState(false);
    const [currentComicBookId, setCurrentComicBookId] = useState(null);

    const editComicBook = (comicBookId) => {
        setCurrentComicBookId(comicBookId);
        setIsDialogOpen(true);
    }

    const closeDialog = () => {
        setIsDialogOpen(false);
    }

    useEffect(() => {
        const getComics = async () => {
            try {
                const accessToken = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`,
                    },
                });
                
                const url = `http://${domain}/api/ComicBook/GetCatalogBackOffice`;

                const catalogResponse = await fetch(url, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,

                    },
                });
                

                const {data} =  await catalogResponse.json();
                
                if(data != null){
                    setComics(data);
                }

            } catch (error) {
                console.error(error);
            }
        };
        getComics();
    }, [getAccessTokenSilently]);

    const deleteComicBook = async (comicBookId) => {
        try {
            const accessToken = await getAccessTokenSilently({
                authorizationParams: {
                    audience: `http://${domain}`,
                },
            });

            const url = `http://${domain}/api/ComicBook/DeleteComicBook/${comicBookId}`;

            const deleteResponse = await fetch(url, {
                method: 'DELETE',
                headers: {
                    Authorization: `Bearer ${accessToken}`,

                },
            });
            window.location.reload();
        } catch (error) {
            console.error(error);
        }
    }

    const onActionComplete = () => {
        window.location.reload();

    };

    return (
        <div className="page">
            <h1 className="title">Comic Books</h1>
            <FilterComicBooks onFilter={handleFilter}></FilterComicBooks>
            <AddComicBookBtn></AddComicBookBtn>
            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Author</th>
                        <th>Edition</th>
                        <th>Price</th>
                        <th>Actions</th>
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
                            <td style={{ width: 20 + 'px' }}>
                                <div className="listActions">
                                    <span className="edit">
                                        <button onClick={() => editComicBook(comic.comicBookId)}>{comic.listButtons[0]?.action}</button>
                                    </span>
                                    {isDialogOpen && <EditComicBookDialog comicBookId={currentComicBookId} onClose={closeDialog} onActionComplete={onActionComplete} />}
                                    <span className="delete">
                                        <button onClick={() => deleteComicBook(comic.comicBookId)}>{comic.listButtons[1]?.action}</button>
                                    </span>
                                </div>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );

    
}
