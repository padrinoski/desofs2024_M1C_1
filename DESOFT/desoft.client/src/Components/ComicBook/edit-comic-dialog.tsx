import { useState, useEffect } from 'react';
import { useAuth0 } from '@auth0/auth0-react';

export default function EditComicBookDialog({comicBookId, onActionComplete}: { comicBookId: any, onActionComplete: () => void }) {

    const domain = `localhost:5265`;
    const { getAccessTokenSilently } = useAuth0();
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [author, setAuthor] = useState('');
    const [version, setVersion] = useState('');
    const [publishingDate, setPublishingDate] = useState('');
    const [price, setPrice] = useState('');


    const [comic, setComic] = useState<any>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const token = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`
                    }
                });
                const response = await fetch(`http://${domain}/api/ComicBook/GetComicBook/${comicBookId}`, {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });

                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                } else {
                    const data = await response.json();
                    setComic(data.data);
                }
            } catch (error) {
                console.error(error);
            }
        };
        fetchData();
        // axios.get(`https://localhost:7242/api/ComicBook/GetComicBook/${comicBookId.comicBookId}`
        // )
        // .then(response => {
        //     setComic(response.data);
        // })
        // .catch(error => {
        //     console.error(error);
        // });

    }, [comicBookId]);

    const comicBookPost = async () => {
        if ((document.getElementById('e-version') as HTMLInputElement).value != '' && !(document.getElementById('version') as HTMLInputElement).validity.valid) {
            window.alert('Unsupported version.')
        } else {
            const formData = new FormData();
            // formData.append("comicBookId", (document.getElementById('e-comicBookId') as HTMLInputElement).value);
            // formData.append("title", (document.getElementById('e-title') as HTMLInputElement).value != '' ? (document.getElementById('e-title') as HTMLInputElement).value : (document.getElementById('e-title') as HTMLInputElement).placeholder);
            // formData.append('description', (document.getElementById('e-description') as HTMLInputElement).value != '' ? (document.getElementById('e-description') as HTMLInputElement).value : (document.getElementById('e-description') as HTMLInputElement).placeholder);
            // formData.append('author', (document.getElementById('e-author') as HTMLInputElement).value != '' ? (document.getElementById('e-author') as HTMLInputElement).value : (document.getElementById('e-author') as HTMLInputElement).placeholder);
            // formData.append('version', (document.getElementById('e-version') as HTMLInputElement).value != '' ? (document.getElementById('e-version') as HTMLInputElement).value : (document.getElementById('e-version') as HTMLInputElement).placeholder);
            // formData.append('publishingDate', (document.getElementById('e-publishingDate') as HTMLInputElement).value != '' ? `${(document.getElementById('e-publishingDate') as HTMLInputElement).value}` : (document.getElementById('e-publishingDate') as HTMLInputElement).placeholder);
            // formData.append('price', (document.getElementById('e-price') as HTMLInputElement).value != '' ? (document.getElementById('e-price') as HTMLInputElement).value : (document.getElementById('e-price') as HTMLInputElement).placeholder);


            formData.append("comicBookId", comicBookId);
            formData.append("title", title !== '' ? title : (document.getElementById('e-title') as HTMLInputElement).placeholder);
            formData.append('description', description !== '' ? description : (document.getElementById('e-description') as HTMLInputElement).placeholder);
            formData.append('author', author !== '' ? author : (document.getElementById('e-author') as HTMLInputElement).placeholder);
            formData.append('version', version !== '' ? version : (document.getElementById('e-version') as HTMLInputElement).placeholder);
            formData.append('publishingDate', publishingDate !== '' ? `${publishingDate}` : (document.getElementById('e-publishingDate') as HTMLInputElement).placeholder);
            formData.append('price', price !== '' ? price : (document.getElementById('e-price') as HTMLInputElement).placeholder);

            let object = {};
            formData.forEach((value, key) => { // @ts-ignore
                object[key] = value});
            let json = JSON.stringify(object);

            try {
                const token = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`
                    }
                });

                const response = await fetch(`http://${domain}/api/ComicBook/EditComicBook/${(document.getElementById('e-comicBookId') as HTMLInputElement).value}`, {
                    method: 'POST',
                    headers: {
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json',
                    },
                    body: json,
                });

                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                } else {
                    onActionComplete();
                    //ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
                }
            } catch (error) {
                // @ts-ignore
                window.alert(error.message);
                console.error(error);
            }
        }
    }

    const setToDate = () => {
        (document.getElementById('e-publishingDate') as HTMLInputElement).type = 'date';
    }

    const setToText = () => {
        (document.getElementById('e-publishingDate') as HTMLInputElement).type = 'text';
    }

    const cancel = () => {
        onActionComplete();
        //ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
    }

    return (
        <div className="editComicBookDialog">
            <input id="e-comicBookId" title="comicBookId" name="comicBookId" type="number" value={comic.comicBookId} hidden readOnly={true}></input>
            <h3>{comic.title}</h3>
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
                        value={title || ''}
                        onChange={e => setTitle(e.target.value)}
                        placeholder={comic.title}
                    ></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Description</label>
                </div>
                <div className="col-8">
                    <input id="e-description" value={description || ''} onChange={e => setDescription(e.target.value)} title="description" name="description" type="text" maxLength={50} placeholder={comic.description}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Author</label>
                </div>
                <div className="col-8">
                    <input id="e-author" title="author" value={author || ''} onChange={e => setAuthor(e.target.value)}name="author" type="text" maxLength={10} placeholder={comic.author}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Version</label>
                </div>
                <div className="col-8">
                    <input id="e-version" title="version" value={version || ''} onChange={e => setVersion(e.target.value)} name="version" type="text" placeholder={comic.version}></input>
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
                           value={publishingDate || ''} onChange={e => setPublishingDate(e.target.value)}
                           placeholder={comic.publishingDate}></input>
                </div>
            </div>
            <div className="row">
                <div className="col-2">
                    <label>Price</label>
                </div>
                <div className="col-8">
                    <input id="e-price" title="price" value={price || ''} onChange={e => setPrice(e.target.value)} name="price" type="number" placeholder={comic.price}></input>
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