import React, {useContext, useState} from 'react';
import "../styles/AuthPage.css"
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";
import {getActor, login} from "../http/userAPI";

const AuthPage = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()

    const [log, setLog] = useState()
    const [password, setPassword] = useState()
    const [jopka, setJopka] = useState()

    // const login = event => {
    //     event.preventDefault();
    //     setIsAuth(true)
    //     localStorage.setItem('auth', 'true')
    //     navigate('/musorka')
    // }

    const signIn = async() =>{
        const responce = await login(log, password)
        if (responce) {
            setIsAuth(true)
            const actor = await getActor(responce.data.data.id)
            localStorage.setItem('actor', JSON.stringify(actor.data.data))
            navigate('/map')
            console.log(responce)
            console.log(actor)
        }
    }

    return (
        <div className="background">
            <div className="AuthPage">
                <img src="/images/Eccooooo.png" alt="Logo" />
                <h1>АВТОРИЗАЦИЯ</h1>
                <form onSubmit={(event) => event.preventDefault()}>
                    <input
                        type="text"
                        placeholder="Имя пользователя"
                        required
                        onChange={(e) => setLog(e.target.value)}
                    />
                    <input
                        type="password"
                        placeholder="Пароль"
                        required
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <button type="submit" onClick={signIn}>
                        Войти
                    </button>
                    <label>
                        <input type="checkbox" />Запомнить меня
                    </label>
                    <a href="#">Забыли пароль?</a>
                </form>
            </div>
        </div>
    );
};

export default AuthPage;