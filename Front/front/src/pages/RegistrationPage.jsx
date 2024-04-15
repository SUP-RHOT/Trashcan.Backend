import React, {useContext, useEffect, useState} from 'react';
import '../styles/RegistrationForm.css'
import {AuthContext} from "../context";
import {useNavigate} from "react-router-dom";
import {registration} from "../http/userAPI";

const RegistrationForm = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [isNameValid, setNameIsValid] = useState(false);
    const [isLastManeValid, setIsLastManeValid] = useState(false);
    const [isSecondManeValid, setIsSecondNameValid] = useState(false);
    const [isLoginValid, setIsLoginValid] = useState(false);
    const [isPasswordValid, setIsPasswordValid] = useState(false);
    const [isPhoneNumberValid, setIsPhoneNumberValid] = useState(false);
    const [isEmailValid, setIsEmailValid] = useState(false);
    const [isCityValid, setIsCityValid] = useState(false);
    const [isStreetValid, setIsStreetValid] = useState(false);
    const [isHouseValid, setIsHouseValid] = useState(false);
    const [isApartmentValid, setIsApartmentValid] = useState(false);
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
    const [showPassword, setShowPassword] = useState(false);
    const handleShowPassword = () => {
        setShowPassword(!showPassword);
    };
    const handleSurnameChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^(?![.])[а-яА-ЯёЁ0-9-._@]{1,63}(?<![.])$/;
        const isValidInput = regex.test(inputValue);
        updateItem('lastName', inputValue)
        setIsLastManeValid(isValidInput);
    };
    const handleLoginChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^(?![.])[a-zA-Z0-9-._]{1,63}(?<![.])$/;
        const isValidInput = regex.test(inputValue);
        updateItem('login', inputValue)
        setIsLoginValid(isValidInput);
    };  const handleEmailChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[a-zA-Z0-9!#$%&'*+-/=?^_`{|}~]+(\.[a-zA-Z0-9!#$%&'*+-/=?^_`{|}~]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z]{2,}$/;
        const isValidInput = regex.test(inputValue);
        updateItem('email', inputValue)
        setIsEmailValid(isValidInput);
    };
    const handlePasswordChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[a-zA-Z0-9!@#$%^&*()_+-=[\]{};':"\\|,.<>/?`~ \t]{8,100}$/;
        const isValidInput = regex.test(inputValue);
        updateItem('password', inputValue)
        setIsPasswordValid(isValidInput);
    };

    const handlePhoneChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[\d+]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('phoneNumber', inputValue)
        setIsPhoneNumberValid(isValidInput);
    };

    const handleNameChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[а-яА-ЯёЁ\s]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('firstName', inputValue)
        setNameIsValid(isValidInput);
    };
    const handleCityChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[а-яА-ЯёЁ\s]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('city', inputValue)
        setIsCityValid(isValidInput);
    };
    const handleStreetChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[а-яА-ЯёЁ\s]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('street', inputValue)
        setIsStreetValid(isValidInput);
    };
    const handleHouseChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[\d+]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('house', inputValue)
        setIsHouseValid(isValidInput);
    };
    const handleApartmenChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[\d+]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('apartment', inputValue)
        setIsApartmentValid(isValidInput);
    };


    const handleSecondNameChange = (event) => {
        const inputValue = event.target.value;
        const regex = /^[а-яА-ЯёЁ\s]+$/;
        const isValidInput = regex.test(inputValue);
        updateItem('secondName', inputValue)
        setIsSecondNameValid(isValidInput);
    };

    const signIn = async() =>{
        try {
            const responce = await registration(user)
            navigate('/auth')
            console.log(responce)
        }catch (e){
            console.log(e)
        }

    }

    return (
        <div className="background">
            <div className="registration-form">
                <h2>ФОРМА РЕГИСТРАЦИИ</h2>
                <form onSubmit={event => event.preventDefault()}>
                    <input
                        type="text"
                        placeholder="Имя"
                        required
                        onChange={e => handleNameChange(e)}
                        style={{
                            border: isNameValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Фамилия"
                        required
                        onChange={e => handleSurnameChange(e)}
                        style={{
                            border: isLastManeValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Отчество"
                        required
                        onChange={e => handleSecondNameChange(e)}
                        style={{
                            border: isSecondManeValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="email"
                        placeholder="Email"
                        required
                        onChange={e => handleEmailChange(e)}
                        style={{
                            border: isEmailValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="tel"
                        placeholder="Номер телефона"
                        required
                        onChange={e => handlePhoneChange(e)}
                        style={{
                            border: isPhoneNumberValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Город"
                        required
                        onChange={e => handleCityChange(e)}
                        style={{
                            border: isCityValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Улица"
                        required
                        onChange={e => handleStreetChange(e)}
                        style={{
                            border: isStreetValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Дом"
                        required
                        onChange={e => handleHouseChange(e)}
                        style={{
                            border: isHouseValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Квартира"
                        required
                        onChange={e => handleApartmenChange(e)}
                        style={{
                            border: isApartmentValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <input
                        type="text"
                        placeholder="Логин"
                        required
                        onChange={e => handleLoginChange(e)}
                        style={{
                            border: isLoginValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <div>
                        <input
                            type={showPassword ? 'text' : 'password'}
                            placeholder="Пароль"
                            required
                            onChange={e => handlePasswordChange(e)}
                            style={{
                                border: isPasswordValid ? '2px solid green' : '2px solid red',
                                padding: '5px',
                                borderRadius: '5px',
                            }}
                        />
                    </div>
                    <input
                        type={showPassword ? 'text' : 'password'}
                        placeholder="Повторите пароль"
                        required
                        style={{
                            border: isPasswordValid ? '2px solid green' : '2px solid red',
                            padding: '5px',
                            borderRadius: '5px',
                        }}
                    />
                    <label>
                        <input type="checkbox" required />
                        Я согласен с правилами проекта сознательный гражданин
                    </label>
                    <label>
                        <input type="checkbox" />
                        Я хочу получать рассылку о новостях проекта на Email
                    </label>
                    <button type="submit" onClick={signIn}>
                        Зарегистрироваться
                    </button>
                </form>
            </div>
        </div>
    );
}

export default RegistrationForm;
