import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { Auth0Provider } from '@auth0/auth0-react'
import NavBar from "./Components/NavBar/NavBar.jsx"
import ErrorPage from "./Components/error-page.jsx"
import ComicBook from "./Components/ComicBook/comic-book.jsx"
import ShoppingCart from "./Components/ShoppingCart/shopping-cart.jsx"
import PlaceOrder from "./Components/PlaceOrder/place-order.jsx"
import OrderHistory from "./Components/OrderHistory/order-history.jsx"
import ViewCostumersOrders from "./Components/OrderHistory/view-customers-orders.jsx"
import {
    BrowserRouter,
    createBrowserRouter,
    RouterProvider,
    Routes,
    Route
} from "react-router-dom";
import axios from 'axios';
import LoginButton from './Authentication/Login/Login.tsx'
import Profile from './Profile/Profile.tsx'

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
    {
        path: "PlaceOrder",
        element: <PlaceOrder />,
    },
    {
        path: "login",
        element: <LoginButton />,
    },
    {
        path: "profile",
        element: <Profile />,
    },
    {
        path: "ShoppingCart",
        element: <ShoppingCart />,
    },
]);

(function () {
    //const token = window.sessionStorage.getItem("token");
    //token admin
    const token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2IiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.NlVN1CIDgT4ITGGpRQPkabyWOgi_VBEL0AUIpBKSW74";

    // token frontoffice
    //const token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxNiIsIm5hbWUiOiJKb2huIERvZSIsImlhdCI6MTUxNjIzOTAyMn0.xK9Se9DVQGOIi6411TCm6y_B5uDWQgqxl5XY9akZcp8";

    axios.defaults.headers.common['Access-Control-Allow-Origin'] = "*";
    axios.defaults.headers.common['Access-Control-Allow-Headers'] = "Origin, X-Requested-With, Content-Type, Accept";
    axios.defaults.headers.common['Authorization'] = token;
    axios.defaults.headers.common['Content-Type'] = "application/json";

    if (token) {
        axios.defaults.headers.common['Authorization'] = token;
    } else {
        axios.defaults.headers.common['Authorization'] = null;
        /*if setting null does not remove `Authorization` header then try
          delete axios.defaults.headers.common['Authorization'];
        */
    }
})();

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Auth0Provider
      domain='dev-b61l3yhgpdw5l2m2.us.auth0.com'
      clientId='a8wEXjcF9dzOlaWF4iICpR0y3LMl4L3m'
      authorizationParams={{redirect_uri: `${window.location.origin}/profile`}}
    >
      <BrowserRouter>
        <NavBar/>
        <Routes>
          <Route path="/" Component={App}/>
          <Route path="/ComicBooks" Component={ComicBook}/>
          <Route path="/OrderHistory" Component={OrderHistory}/>
          <Route path="/CostumersOrders" Component={ViewCostumersOrders}/>
          <Route path="/login" Component={LoginButton} />
          <Route path="/profile" Component={Profile} />
          <Route path="/PlaceOrder" Component={PlaceOrder} />
          <Route path="/ShoppingCart" Component={ShoppingCart} />
          <Route Component={ErrorPage} />
        </Routes>
      </BrowserRouter>
    </Auth0Provider>
  </React.StrictMode>
)

//        <RouterProvider router={router} />
