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

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
    <BrowserRouter>
        <NavBar />
    </BrowserRouter>
  </React.StrictMode>,
)
