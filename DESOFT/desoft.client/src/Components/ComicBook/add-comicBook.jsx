import React from 'react';
import AddComicBookDialog from './add-comic-dialog';
import ReactDom from 'react-dom';

const showDialog = () => {

    ReactDom.render(<AddComicBookDialog></AddComicBookDialog>, document.querySelector('.page'));

}

export default function AddComicBookBtn() {

    return (
        <div className="btnAdd">
            <span>
                <a onClick={() => showDialog()} >Add Comic Book</a>
            </span>
        </div>
    );
}
