import React, { useState } from 'react';
import '../styles/Profile.css';
import {useNavigate} from "react-router-dom";

const EditProfile = () => {
    const [editedData, setEditedData] = useState({
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
        street: ""});

    const navigate = useNavigate()
    const handleChange = (e) => {
        const { name, value } = e.target;
        setEditedData({ ...editedData, [name]: value });
    };
const updateProfile =() =>{
    navigate('/profile')
}

    return (
        <div className="profile" style={{ fontSize: "1.2em" }}>
            <h2 className="profile__title">Ваши данные</h2>
            <div className="profile__row">
                <div className="profile__label">Имя:</div>
                <input
                    type="text"
                    name="firstName"
                    value={editedData.firstName}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <div className="profile__label">Фамилия:</div>
                <input
                    type="text"
                    name="lastName"
                    value={editedData.lastName}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <div className="profile__label">Город:</div>
                <input
                    type="text"
                    name="city"
                    value={editedData.city}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <div className="profile__label">Улица:</div>
                <input
                    type="text"
                    name="street"
                    value={editedData.street}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <div className="profile__label">Дом:</div>
                <input
                    type="text"
                    name="house"
                    value={editedData.house}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <div className="profile__label">Номер телефона:</div>
                <input
                    type="text"
                    name="phoneNumber"
                    value={editedData.phoneNumber}
                    onChange={handleChange}
                />
            </div>
            <div className="profile__row">
                <button onClick={updateProfile}>Обновить</button>
            </div>
        </div>
    );
};

export default EditProfile;
