import React, {useContext, useState} from 'react';
import "./styles/AuthPage.css"
import {AuthContext} from "./context";
import {useNavigate} from "react-router-dom";
import {login, registration} from "./http/userAPI";

const AuthPage = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()

    const [log, setLog] = useState()
    const [password, setPassword] = useState()

    // const login = event => {
    //     event.preventDefault();
    //     setIsAuth(true)
    //     localStorage.setItem('auth', 'true')
    //     navigate('/musorka')
    // }

    const signIn = async() =>{
        const responce = await login(log, password)
        console.log(responce)
    }

    return (
        <div className="container">
             <h1>Authorization</h1>
            <form onSubmit={event => event.preventDefault()}>
                <input type="text" placeholder="Username/Email" required onChange={e => setLog(e.target.value)} />
                <input type="password" placeholder="Password" required onChange={e => setPassword(e.target.value)} />
                <button type="submit" onClick={signIn}>Login</button>
                <label><input type="checkbox" /> Remember Me</label>
                <a href="#">Forgot Password?</a>
            </form>
        </div>
    );
};

export default AuthPage;