import { useEffect } from 'react';
import  ReactDom from 'react-dom';
import ComicBook from "./comic-book";
import axios from 'axios';

export default function AddComicBookDialog() {

    useEffect(() => {
        
    }, []);

    const comicBookPost = () => {

        if (document.getElementById('title') == '' || document.getElementById('description').value == '' ||
            document.getElementById('author') == '' || document.getElementById('publishingDate').value == '' ||
            document.getElementById('version') == '' || document.getElementById('price').value == '') {
            window.alert('One or more validation errors occurred.');
        } else {
            if (!document.getElementById('version').validity.valid) {
                window.alert('Unsupported version.')
            } else {
                var formData = new FormData();

                formData.append("title", document.getElementById('title').value);
                formData.append('description', document.getElementById('description').value);
                formData.append('author', document.getElementById('author').value);
                formData.append('version', document.getElementById('version').value);
                formData.append('publishingDate', `${document.getElementById('publishingDate').value}T${new Date().getHours()}:${new Date().getMinutes()}:00.000Z`);
                formData.append('price', document.getElementById('price').value);


                axios.post(`https://localhost:7242/api/ComicBook/CreateComicbook`, formData
                )
                    .then(response => {
                        console.log(response.data);
                        ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
                    })
                    .catch(error => {
                        window.alert(error.response.data.title)
                        console.error(error);
                    });
            }
        }
    }

    const cancel = () => {
        ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));

    }

    return (
        <div className="addComicBookDialog">
            <h3>Add Comic Book</h3>
            <div className="row">
                <div className="col-2">
                    <label>Title</label>
                </div>
                <div className="col-8">
                    <input id="title" title="title" name="title" type="text" maxLength={20}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Description</label>
                </div>
                <div className="col-8">
                    <input id="description" title="description" name="description" type="text" maxLength={50}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Author</label>
                </div>
                <div className="col-8">
                    <input id="author" title="author" name="author" type="text" maxLength={10}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Version</label>
                </div>
                <div className="col-8">
                    <input id="version" title="version" name="version" type="text" pattern="\d{1,2}(.\d{1,2}){0,2}"></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Publishing Date</label>
                </div>
                <div className="col-8">
                    <input id="publishingDate" title="publishingDate" name="publishingDate" type="date"></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Price</label>
                </div>
                <div className="col-8">
                    <input id="price" title="price" name="price" type="number" ></input>
                </div>
            </div>
            <div className="row">
                <div className="buttons">
                    <button onClick={() => cancel()}> Cancel</button>
                    <button id="addBtn" onClick={() => comicBookPost()}> Add </button>
                </div>
            </div>
        </div>
    );
}