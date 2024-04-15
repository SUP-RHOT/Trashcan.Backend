import React, {useContext} from 'react';
import {Link, NavLink} from 'react-router-dom';
import '../styles/mapa.css';
import {AuthContext} from "../context";

const Mapa = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const logout = () => {
        setIsAuth(false)
        localStorage.removeItem('token')
        localStorage.removeItem('rToken')
        localStorage.removeItem('actor')
        localStorage.removeItem('actorId')
    }
  return (
    <>
      <header className="header">
        <img src="/images/Eccooooo.png" alt="Logo" className="logo" />
        <div className="buttons" style={{marginTop: '20px'}}>
          <Link to="/about" className="button">О ПРОЕКТЕ</Link>
          <button className="button">Политика конфиденциальности</button>
            {isAuth ? <Link to="/profile" className="button">ПРОФИЛЬ</Link> : ''}
            {isAuth ? <Link to="/addressForm" className="button">ДОБАВИТЬ ПО АДРЕСУ</Link> : ''}
            {isAuth ? <Link to="/adminPanel" className="button">ПАНЕЛЬ АДМИНА</Link> : ''}
            {!isAuth ? <Link to="/auth" className="button">ВОЙТИ</Link> : <Link onClick={logout} to="/home" className="button">Выйти</Link>}
            {!isAuth ? <Link to="/register" className="button">ЗАРЕГИСТРИРОВАТЬСЯ</Link> : ''}
        </div>
      </header>

      <div style={{textAlign: 'center', marginTop: '40px'}}>
        <h1 style={{color: '#69842b', fontSize: '23px'}}>ECO CITIZEN</h1>
        <p>Это проект, помогающий сохранить экологию наших городов. Отмечайте на карте точки нарушения чистоты и порядка, сделайте этот мир лучше!</p>
      </div>

      <h2 style={{textAlign: 'center', marginTop: '40px', color: '#69842b', fontSize: '23px'}}>РУБРИКИ</h2>

      <div className="rubrics-container" style={{backgroundColor: '#ccc', padding: '20px', width: '1300px', margin: '0 auto', overflow: 'auto', display: 'flex', justifyContent: 'space-around', flexWrap: 'wrap'}}>
        <div className="rubric-wrapper" style={{backgroundColor: '#fff', border: '1px solid #ccc', margin: '20px', width: '388px', height: '554px', display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
          <div className="rubric" style={{textAlign: 'center', marginTop: '20px'}}>
            <h3 style={{color: '#000000', fontSize: '20px'}}>ПАРКОВКИ</h3>
            <img src="/images/3.jpg" alt="Rubric Image 1" />
            <Link to="/map" className="button">ОТМЕТИТЬ НА КАРТЕ</Link>
          </div>
        </div>
        <div className="rubric-wrapper" style={{backgroundColor: '#fff', border: '1px solid #ccc', margin: '20px', width: '388px', height: '554px', display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
          <div className="rubric" style={{textAlign: 'center', marginTop: '20px'}}>
            <h3 style={{color: '#000000', fontSize: '20px'}}>ПРОДУКТЫ</h3>
            <img src="/images/2.jpg" alt="Rubric Image 2" />
            <Link to="/map" className="button">ОТМЕТИТЬ НА КАРТЕ</Link>
          </div>
        </div>
        <div className="rubric-wrapper" style={{backgroundColor: '#fff', border: '1px solid #ccc', margin: '20px', width: '388px', height: '554px', display: 'flex', flexDirection: 'column', alignItems: 'center'}}>
          <div className="rubric" style={{textAlign: 'center', marginTop: '20px'}}>
            <h3 style={{color: '#000000', fontSize: '20px'}}>МУСОР</h3>
            <img src="/images/1.jpg" alt="Rubric Image 3" />
            <Link to="/map" className="button">ОТМЕТИТЬ НА КАРТЕ</Link>
          </div>
        </div>
      </div>

      <footer style={{backgroundColor: '#333', color: 'white', padding: '20px 0', textAlign: 'center', marginTop: '40px'}}>
        <p>ECO CITIZEN</p>
        <p>Проект, направленный на улучшение экологии</p>
        <p>Вы можете связаться с нами:</p>
        <div className="footer-buttons" style={{display: 'flex', justifyContent: 'center', marginTop: '20px'}}>
          <button className="footer-button"><img src="/images/VK.png" alt="VK" /></button>
          <button className="footer-button"><img src="/images/TG.png" alt="Telegram" /></button>
          <button className="footer-button"><img src="/images/GM.png" alt="Email" /></button>
        </div>
      </footer>

      <div className="rights" style={{backgroundColor: '#333', color: 'white', padding: '10px 0', textAlign: 'center'}}>
        <p>ПРАВА НЕ ЗАЩИЩЕНЫ КОМПАНИЯ ОООCITIZEN</p>
      </div>
    </>
  );
};

export default Mapa;
