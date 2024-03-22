
import AuthPage from './AuthPage';
import HomePage from './HomePage';
import RegistrationForm from './pages/RegistrationPage';
import './styles/App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import {AuthContext} from "./context";
import {useEffect, useState} from "react";

const router = createBrowserRouter([
  {
      path: "/musorka/",
      element: <HomePage/>,
      children:[
          {
              path: "/musorka/auth",
              element: <AuthPage/>,
          },
          {
            path: "/musorka/register",
            element: <RegistrationForm/>,
        }
      ]
  },
]);

function App() {

    const [isAuth, setIsAuth] = useState(false)
    useEffect(() =>{
        if (localStorage.getItem('auth')){
            setIsAuth(true)
        }
    })

  return (
      <AuthContext.Provider value={{
          isAuth,
          setIsAuth
      }}>
          <div className='app-container'>
              <RouterProvider router={router} />
          </div>
      </AuthContext.Provider>
  );
}

export default App;
