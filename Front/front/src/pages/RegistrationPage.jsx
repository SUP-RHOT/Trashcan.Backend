import React, {useContext, useEffect, useState} from 'react';
import '../styles/RegistrationForm.css'
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";
import {registration} from "../http/userAPI";

const RegistrationForm = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()
    const [user, setUser] = useState({
        "lastName": "",
        "firstName": "",
        "secondName": "",
        "login": "",
        "password": "",
        "phoneNumber": "",
        "email": "",
        "city": "",
        "street": "",
        "house": "",
        "apartment": "",
    })

    const updateItem = (key, value) => {
        setUser(prevUser => ({
            ...prevUser,
            [key]: value
        }));
    };
    const login = event => {
        event.preventDefault();
        setIsAuth(true)
        localStorage.setItem('auth', 'true')
        navigate('/musorka')
    }

    const signIn = async() =>{
        const responce = await registration(user)
        navigate('/auth')
        console.log(responce)
    }

    return (
        <div className="registration-form">
            <h2>Форма регистрации</h2>
            <form onSubmit={event => event.preventDefault()}>
                <input type="text" placeholder="Имя" required onChange={e => updateItem('firstName', e.target.value)}/>
                <input type="text" placeholder="Фамилия" required onChange={e => updateItem('lastName', e.target.value)}/>
                <input type="text" placeholder="Отчество" required onChange={e => updateItem('secondName', e.target.value)}/>
                <input type="email" placeholder="Email" required onChange={e => updateItem('email', e.target.value)}/>
                <input type="tel" placeholder="Телефонный номер" required onChange={e => updateItem('phoneNimber', e.target.value)} />
                <input type="text" placeholder="Город" required onChange={e => updateItem('city', e.target.value)}/>
                <input type="text" placeholder="Улица" required onChange={e => updateItem('street', e.target.value)}/>
                <input type="text" placeholder="Дом" required onChange={e => updateItem('house', e.target.value)}/>
                <input type="text" placeholder="Квартира" required onChange={e => updateItem('apartment', e.target.value)}/>
                <input type="text" placeholder="Логин" required onChange={e => updateItem('login', e.target.value)}/>
                <input type="password" placeholder="Пароль" required onChange={e => updateItem('password', e.target.value)}/>
                <input type="password" placeholder="Повторите пароль" required/>
                <label>
                    <input type="checkbox" required />
                    Я согласен с правилами проекта сознательный гражданин
                </label>
                <label>
                    <input type="checkbox" />
                    Я хочу получать рассылку о новостях проекта на Email
                </label>
                <button type="submit" onClick={signIn}>Register</button>
            </form>
        </div>
    );
}

export default RegistrationForm;
