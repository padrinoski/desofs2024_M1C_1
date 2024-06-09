import { useEffect } from 'react';
import { useAuth0 } from '@auth0/auth0-react';

// @ts-ignore
export default function AddComicBookDialog({onActionCompleted}) {

    const { getAccessTokenSilently } = useAuth0();
    const domain = `localhost:5265`;

    useEffect(() => {

    }, []);

    const comicBookPost = async () => {

        if ((document.getElementById('title') as HTMLInputElement).value == '' || (document.getElementById('description') as HTMLInputElement).value == '' ||
            (document.getElementById('author') as HTMLInputElement).value == '' || (document.getElementById('publishingDate') as HTMLInputElement).value == '' ||
            (document.getElementById('version') as HTMLInputElement).value == '' || (document.getElementById('price') as HTMLInputElement).value == '') {
            window.alert('One or more validation errors occurred.');
        } else {
            if (!(document.getElementById('version') as HTMLInputElement).validity.valid) {
                window.alert('Unsupported version.')
            } else {
                const formData = new FormData();

                formData.append("Title", (document.getElementById('title') as HTMLInputElement).value);
                formData.append('Description', (document.getElementById('description') as HTMLInputElement).value);
                formData.append('Author', (document.getElementById('author') as HTMLInputElement).value);
                formData.append('Version', (document.getElementById('version') as HTMLInputElement).value);
                formData.append('PublishingDate', `${(document.getElementById('publishingDate') as HTMLInputElement).value}T${new Date().getHours()}:${new Date().getMinutes()}:00.000Z`);
                formData.append('Price', (document.getElementById('price') as HTMLInputElement).value);

                let object = {};
                formData.forEach((value, key) => { // @ts-ignore
                    object[key] = value});
                let json = JSON.stringify(object);

                try{
                    const token = await getAccessTokenSilently({
                        authorizationParams: {
                            audience: `http://${domain}`,
                        }
                    });

                    const response = await fetch(`http://${domain}/api/ComicBook/CreateComicbook`, {
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
                        //ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
                        onActionCompleted();
                    }
                }catch(error){
                    // @ts-ignore
                    window.alert(error.message);
                    console.error(error);
                }
            }
        }
    }

    const cancel = () => {
        //ReactDom.render(<ComicBook></ComicBook>, document.querySelector('.page'));
        onActionCompleted();
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