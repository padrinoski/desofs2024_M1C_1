import React, { useState, useEffect } from 'react';
import axios from 'axios';
import AddComicBookBtn from './add-comicBook';
import EditComicBookDialog from './edit-comic-dialog';
import ReactDom from 'react-dom';

export default function ComicBookBackOffice() {

    const [comics, setComics] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7242/api/ComicBook/GetCatalogBackOffice'
        )
        .then(response => {
            setComics(response.data);
        })
        .catch(error => {
            console.error(error);
        });

    }, []);


    const editComicBook = (comicBookId) => {
        ReactDom.render(<EditComicBookDialog comicBookId={comicBookId}></EditComicBookDialog>, document.querySelector('.page'));
        ReactDom.render(<ComicBook/>, document.querySelector('.page'));
        //document.querySelector('.editComicBookDialog')?.removeAttribute('hidden');
    }

    const deleteComicBook= (comicBookId) => {
        console.log(comicBookId);
    }

    return (
        <div className="page">
            <h1 className="title">Comic Books</h1>
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
                    {comics.data?.map(comic => (
                        <tr key={comic.comicBookId}>
                            <td>{comic.title}</td>
                            <td>{comic.description}</td>
                            <td>{comic.author}</td>
                            <td>{comic.version}</td>
                            <td>{comic.price}&euro;</td>
                            <td style={{ width: 20 + 'px' }}>
                                <div className="listActions">
                                    <span className="edit">
                                        <button onClick={() => editComicBook(comic.comicBookId)}>{comic.listButtons[0].action}</button>
                                    </span>
                                    <span className="delete">
                                        <button onClick={() => deleteComicBook(comic.comicBookId)}>{comic.listButtons[1].action}</button>
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
