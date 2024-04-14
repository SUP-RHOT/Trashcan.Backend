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
            <Navbar/>
            <div className="home-container">
                <div style={{marginTop:'700px'}} id="detail">
                    <Outlet />
                </div>
                
            </div>
        </div>
    );
}

export default HomePage;