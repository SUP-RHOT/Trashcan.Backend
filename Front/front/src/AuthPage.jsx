import React from 'react';
import "./styles/AuthPage.css"

const AuthPage = () => {
    return (
        <div className="container">
             <h1>Authorization</h1>
            <form>
                <input type="text" placeholder="Username/Email" required />
                <input type="password" placeholder="Password" required />
                <button type="submit">Login</button>
                <label><input type="checkbox" /> Remember Me</label>
                <a href="#">Forgot Password?</a>
            </form>
        </div>
    );
};

export default AuthPage;