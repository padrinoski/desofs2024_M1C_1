import React, { useEffect, useState } from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import ComicBookBackOffice from './comic-book-backOffice';
import ComicBookFrontOffice from './comic-book-frontOffice';

export default function ComicBook() {
    const { user, isAuthenticated, isLoading } = useAuth0();
    const [backOffice, setbackOffice] = useState(false);

    useEffect(() => {
        if (isAuthenticated && user != null) {
            if (user.name == "Admin" || user.name == "Manager" || user.name == "Clerk") {
                setbackOffice(true);
            }
        }
    }, [isAuthenticated, user]);

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (backOffice) {
        return <ComicBookBackOffice />;
    } else {
        return <ComicBookFrontOffice />;
    }
}