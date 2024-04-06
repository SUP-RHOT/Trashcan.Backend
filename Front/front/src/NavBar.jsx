import React, {useContext} from 'react';
import './styles/Navbar.css';
import {NavLink, useNavigate} from "react-router-dom";
import {AuthContext} from "./context";

const Navbar = () => {

    const {isAuth, setIsAuth} = useContext(AuthContext)
    const navigate = useNavigate()
    const logout = () => {
        setIsAuth(false)
        localStorage.removeItem('auth')
    }

    return (
        <div className="navbar">
            <button><NavLink to="/musorka">Домой</NavLink></button>
            <button>О нас</button>
            <button>Контакты</button>
            {!isAuth ? <button><NavLink to="/musorka/auth" >Войти</NavLink></button> : <button onClick={logout}>Выйти</button>}
            {!isAuth ? <button><NavLink to="/musorka/register" >Зарегестрироваться</NavLink></button> : ''}

        </div>
    );
}

export default Navbar;