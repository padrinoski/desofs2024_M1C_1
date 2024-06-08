import axios from 'axios';
import ReactDom from 'react-dom';
import { useState, useEffect } from 'react';
import ComicBook from "./comic-book";

export default function EditComicBookDialog(comicBookId : comicBook) {

    const title = document.getElementById('title');
    const description = document.getElementById('description');
    const author = document.getElementById('author');
    const version = document.getElementById('version');
    const publishingDate = document.getElementById('publishingDate');
    const price = document.getElementById('price');

    const [comic, setComic] = useState([]);

    useEffect(() => {
        axios.get(`https://localhost:7242/api/ComicBook/GetComicBook/${comicBookId.comicBookId}`
        )
        .then(response => {
            console.log(response.data);
            setComic(response.data);
        })
        .catch(error => {
            console.error(error);
        });

    }, []);

    const comicBookPost = () => {
        document.querySelector('.editComicBookDialog')?.setAttribute('hidden', 'true');
    }

    const setToDate = () => {
        document.getElementById('e-publishingDate').type = 'date';
    }

    const setToText = () => {
        document.getElementById('e-publishingDate').type = 'text';
    }

    const cancel = () => {
        ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
    }

    return (
        <div className="editComicBookDialog">
            <input id="e-comicBookId" title="comicBookId" name="comicBookId" type="number" value={comic.data?.comicBookId} hidden readOnly={true}></input>
            <h3>{comic.data?.title}</h3>
            <div className="row">
                <div className="col-2">
                    <label>Title</label>
                </div>
                <div className="col-8">
                    <input
                        id="e-title"
                        title="title"
                        name="title"
                        type="text"
                        maxLength={20}  
                        placeholder={comic.data?.title}
                    ></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Description</label>
                </div>
                <div className="col-8">
                    <input id="e-description" title="description" name="description" type="text" maxLength={50} placeholder={comic.data?.description}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Author</label>
                </div>
                <div className="col-8">
                    <input id="e-author" title="author" name="author" type="text" maxLength={10} placeholder={comic.data?.author}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Version</label>
                </div>
                <div className="col-8">
                    <input id="e-version" title="version" name="version" type="text" placeholder={comic.data?.version}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Publishing Date</label>
                </div>
                <div className="col-8">
                    <input id="e-publishingDate" title="publishingDate" name="publishingDate" type="text"
                        onFocus={() => setToDate()}
                        onBlur={() => setToText()}
                        placeholder={comic.data?.publishingDate}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Price</label>
                </div>
                <div className="col-8">
                    <input id="e-price" title="price" name="price" type="number" placeholder={comic.data?.price}></input>
                </div>
            </div>
            <div className="row">
                <div className="buttons">
                    <button onClick={() => cancel()}> Cancel</button>
                    <button id="addBtn" onClick={() => comicBookPost()}> Save Changes </button>
                </div>
            </div>
        </div>

    );
}