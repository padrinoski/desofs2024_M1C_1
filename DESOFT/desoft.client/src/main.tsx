import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import NavBar from './Components/NavBar/NavBar.jsx'
import ErrorPage from "./Components/error-page"
import ComicBook from "./Components/ComicBook/comic-book"
import {
    BrowserRouter,
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import axios from 'axios';

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        errorElement: <ErrorPage />,
    },
    {
        path: "ComicBooks",
        element: <ComicBook />,
    },
]);

(function () {
    //const token = window.sessionStorage.getItem("token");
    const token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2IiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.NlVN1CIDgT4ITGGpRQPkabyWOgi_VBEL0AUIpBKSW74eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2IiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.NlVN1CIDgT4ITGGpRQPkabyWOgi_VBEL0AUIpBKSW74";
    axios.defaults.headers.common['Access-Control-Allow-Origin'] = "*";
    axios.defaults.headers.common['Access-Control-Allow-Headers'] = "Origin, X-Requested-With, Content-Type, Accept";
    axios.defaults.headers.common['Authorization'] = token;

    //if (token) {
    //    axios.defaults.headers.common['Authorization'] = token;
    //} else {
    //    axios.defaults.headers.common['Authorization'] = null;
    //    /*if setting null does not remove `Authorization` header then try     
    //      delete axios.defaults.headers.common['Authorization'];
    //    */
    //}
})();

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter>
        <NavBar />
        </BrowserRouter>
        <RouterProvider router={router} />
  </React.StrictMode>,
)
