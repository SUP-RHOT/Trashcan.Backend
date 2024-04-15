import React from 'react';
import '../styles/HomePage.css';
import Navbar from '../components/NavBar';
import {
    Outlet,
    useNavigate
} from "react-router-dom";

const HomePage = () => {
    return (
        <div>
            <div className="home-container">
                <div className={window.location.href == 'http://localhost:3000/adminPanel' ? "marTop" : ""} id="detail">
                    <Outlet />
                </div>
                
            </div>
        </div>
    );
}

export default HomePage;