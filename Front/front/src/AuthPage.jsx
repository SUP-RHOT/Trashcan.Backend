import React, {useContext, useState} from 'react';
import "./styles/AuthPage.css"
import {AuthContext} from "./context";
import {useNavigate} from "react-router-dom";

const AuthPage = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()
    const login = event => {
        event.preventDefault();
        setIsAuth(true)
        localStorage.setItem('auth', 'true')
        navigate('/musorka')
    }

    return (
        <div className="container">
             <h1>Authorization</h1>
            <form onSubmit={login}>
                <input type="text" placeholder="Username/Email" required />
                <input type="password" placeholder="Password" required />
                <button type="submit">Login</button>
                <label><input type="checkbox" /> Remember Me</label>
                <a href="#">Forgot Password?</a>
            </form>
        </div>
    );
};

export default AuthPage;