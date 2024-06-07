import './NavBar.css';
import React, { useEffect } from 'react';
import { Link } from "react-router-dom";

function NavBar() {

    useEffect(() => {
        const script = document.createElement('script');

        script.src = "../../src/Components/NavBar/navbar.js";
        script.defer = true;

        document.body.appendChild(script);

        return () => {
            document.body.removeChild(script);
        }
    }, []);

    return (
        <>
            <div className="topnav">
                <div className="leftPane">
                    <Link id="homeBtn" to={`/`}>Home</Link>
                    <Link id="comicBooksBtn" to={`ComicBooks`}>ComicBooks</Link>
                    <a href="#">Contact</a>
                    <a href="#">About</a>
                </div>
                <div className="rightPane">
                    <a href="#">Sign-in</a>
                
                </div>
            </div> 
        </>
  );
}

export default NavBar;