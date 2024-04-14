import React, {useContext} from 'react';
import '../styles/Navbar.css';
import {NavLink, useNavigate} from "react-router-dom";
import {AuthContext} from "../context";
import {check, getActor, login} from "../http/userAPI";

const Navbar = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()
    const logout = () => {
        setIsAuth(false)
        localStorage.removeItem('token')
        localStorage.removeItem('rToken')
        localStorage.removeItem('actor')
        localStorage.removeItem('actorId')
    }

    const refresh = async() =>{
        const responce = await check()
        console.log(responce)
    }

    const actor = async() =>{
        const responce = await getActor(1)
        console.log(responce)
    }

    return (
        <div className="navbar">
            <button><NavLink to="/map">Домой</NavLink></button>
            <button>О нас</button>
            <button><NavLink to="/addressForm">Добавить по адрессу</NavLink></button>
            {isAuth ? <button><NavLink to="/profile" >Профиль</NavLink></button> : ''}
            {isAuth ? <button><NavLink to="/adminPanel" >Панель Админа</NavLink></button> : ''}
            {!isAuth ? <button><NavLink to="/auth" >Войти</NavLink></button> : <button onClick={logout}><NavLink to="/map" >Выйти</NavLink></button>}
            {!isAuth ? <button><NavLink to="/register" >Зарегестрироваться</NavLink></button> : ''}

        </div>
    );
}

export default Navbar;