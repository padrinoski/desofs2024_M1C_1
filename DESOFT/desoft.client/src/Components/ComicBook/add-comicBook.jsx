import React, { useState } from 'react';
import AddComicBookDialog from './add-comic-dialog';
import ComicBook from './comic-book';

export default function AddComicBookBtn() {
    const [showDialog, setShowDialog] = useState(false);
    const [showComicBook, setShowComicBook] = useState(false);


    const toggleDialog = () => {
        setShowDialog(!showDialog);
    }

    const onActionCompleted = () => {
        setShowDialog(false);
        setShowComicBook(true);
    }

    return (
        <div className="btnAdd">
            <span>
                <a onClick={toggleDialog}>Add Comic Book</a>
            </span>
            {showDialog && <AddComicBookDialog onActionCompleted={onActionCompleted} />}
            {showComicBook && window.location.reload()}
        </div>
    );
}