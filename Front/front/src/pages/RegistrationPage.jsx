import React from 'react';
import '../styles/RegistrationForm.css'

const RegistrationForm = () => {
    return (
        <div className="registration-form">
            <h2>Форма регистрации</h2>
            <form>
                <input type="text" placeholder="Имя" required />
                <input type="email" placeholder="Email" required />
                <input type="password" placeholder="Пароль" required />
                <input type="password" placeholder="Повторите пароль" required />
                <label>
                    <input type="checkbox" required />
                    Я согласен с правилами проекта сознательный гражданин
                </label>
                <label>
                    <input type="checkbox" required />
                    Я хочу получать рассылку о новостях проекта на Email
                </label>
                <button type="submit">Register</button>
            </form>
        </div>
    );
}

export default RegistrationForm;
