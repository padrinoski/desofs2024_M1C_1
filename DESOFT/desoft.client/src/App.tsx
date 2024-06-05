import { useEffect, useState } from 'react';
import './App.css';
import LoginButton from './Authentication/Login/Login';
import { BrowserRouter,Routes, Route,  } from 'react-router-dom';
import Profile from './Profile/Profile';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" Component={LoginButton}/>
                <Route path="/profile" Component={Profile}/>
            </Routes>
        </BrowserRouter>
    );
}

export default App;