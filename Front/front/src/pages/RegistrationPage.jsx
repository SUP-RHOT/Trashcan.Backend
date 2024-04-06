import React, {useContext, useEffect} from 'react';
import '../styles/RegistrationForm.css'
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";

const RegistrationForm = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()
    const login = event => {
        event.preventDefault();
        setIsAuth(true)
        localStorage.setItem('auth', 'true')
        navigate('/musorka')
    }

    return (
        <div className="registration-form">
            <h2>Форма регистрации</h2>
            <form onSubmit={login}>
                <input type="text" placeholder="Имя" required />
                <input type="email" placeholder="Email" required />
                <input type="password" placeholder="Пароль" required />
                <input type="password" placeholder="Повторите пароль" required />
                <label>
                    <input type="checkbox" required />
                    Я согласен с правилами проекта сознательный гражданин
                </label>
                <label>
                    <input type="checkbox" />
                    Я хочу получать рассылку о новостях проекта на Email
                </label>
                <button type="submit">Register</button>
            </form>
        </div>
    );
}

export default RegistrationForm;
