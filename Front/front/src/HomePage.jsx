import React from 'react';
import './styles/HomePage.css';
import Navbar from './NavBar';
import {
    Outlet,
    useNavigate
} from "react-router-dom";

const HomePage = () => {
    return (
        <div>
            <Navbar/>
            <div className="home-container">
                <div id="detail">
                    <Outlet />
                </div>
                
            </div>
        </div>
    );
}

export default HomePage;