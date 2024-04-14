import React, {useEffect, useState} from 'react';
import '../styles/Profile.css';
import {getActor} from "../http/userAPI";
import {NavLink, useNavigate} from "react-router-dom";

const Profile = () => {

    const [data, setData] = useState({
        apartment: null,
        city: "",
        email: "",
        firstName: "",
        house: "",
        id: 5,
        lastName: "",
        login: "",
        phoneNumber: "",
        secondName: "",
        street: ""})

    const actor = async() =>{
        const responce = await getActor(5)
        return responce.data.data
    }

    const navigate = useNavigate()

    useEffect(() => {
        // Your function to execute once here
        // actor().then(data => {
        //     setData(data)
        // })
        setData(JSON.parse(localStorage.getItem('actor')))
    }, []);

    return (
        <div className="profile" style={{fontSize:"1.2em"}}>
            <h2 className="profile__title">Ваши данные</h2>
            <div className="profile__row">
                <div className="profile__label">Имя:</div>
                <div className="profile__value">{data.firstName}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Фамилия:</div>
                <div className="profile__value">{data.lastName}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Город:</div>
                <div className="profile__value">{data.city}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Улица:</div>
                <div className="profile__value">{data.street}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Дом:</div>
                <div className="profile__value">{data.house}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Логин:</div>
                <div className="profile__value">{data.login}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Email:</div>
                <div className="profile__value">{data.email}</div>
            </div>
            <div className="profile__row">
                <div className="profile__label">Номер телефона:</div>
                <div className="profile__value">{data.phoneNumber}</div>
            </div>
            <button onClick={() => {navigate('/profile/edit')}}>Изменить данные</button>
        </div>
    );
};

export default Profile;
