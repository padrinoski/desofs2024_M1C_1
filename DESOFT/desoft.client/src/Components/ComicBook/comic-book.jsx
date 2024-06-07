import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function ComicBook() {

    //const [posts, setPosts] = useState([]);

    //useEffect(() => {
    //    axios.get('https://jsonplaceholder.typicode.com/posts')
    //        .then(response => {
    //            setPosts(response.data);
    //        })
    //        .catch(error => {
    //            console.error(error);
    //        });
    //}, []);

    //return (
    //    <div className="page">
    //        <h1>Comic Books</h1>
    //        <ul>
    //            {posts.map(post => (
    //                <li key={post.id}>{post.title}</li>
    //            ))}
    //        </ul>
    //    </div>
    //);


    const [comics, setComics] = useState([]);

    useEffect(() => {
        console.log(axios.defaults.headers.common['Authorization']);
        axios.get('https://localhost:7242/api/ComicBook/GetCatalog'
        )
            .then(response => {
                console.log(response.data);
                setComics(response.data);
            })
            .catch(error => {
                console.error(error);
            });

    }, []);

    return (
        <div className="page">
            <h1>Comic Books</h1>
            <table>
                {comics.map(comic => (
                    <tr>{comic.Title}</tr>
                ))}
            </table>
        </div>
    );
}
