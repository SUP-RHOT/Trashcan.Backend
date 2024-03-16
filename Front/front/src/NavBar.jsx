import React from 'react';
import './styles/Navbar.css';

const Navbar = () => {
    return (
        <div className="navbar">
            <button>Домой</button>
            <button>О нас</button>
            <button>Контакты</button>
            <button>Зарегестрироваться</button>
            <button>Войти</button>
        </div>
    );
}

export default Navbar;