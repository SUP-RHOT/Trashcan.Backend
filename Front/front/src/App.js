
import AuthPage from './pages/AuthPage';
import HomePage from './pages/HomePage';
import RegistrationForm from './pages/RegistrationPage';
import './styles/App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import {AuthContext, CurMarkerLock} from "./context";
import {useEffect, useState, } from "react";
import MapComponent from "./pages/map";
import Profile from "./pages/Profile";
import AddressForm from "./pages/AddressForm";
import AdminPanel from "./pages/AdminPanel";
import EditProfile from "./pages/EditProfile";
import Mapa from "./pages/Mapa";


const router = createBrowserRouter([
  {
      path: "/",
      element: <HomePage/>,
      children:[
          {
              path: "/auth",
              element: <AuthPage/>,
          },
          {
            path: "/register",
            element: <RegistrationForm/>,
          },
          {
              path: "/map",
              element: <MapComponent/>,
          },
          {
              path: "/profile",
              element: <Profile/>,
          },
          {
              path: "/profile/edit",
              element: <EditProfile/>,
          },
          {
              path: "/addressForm",
              element: <AddressForm/>,
          },
          {
              path: "/adminPanel",
              element: <AdminPanel/>,
          },
          {
              path: "/adminPanel",
              element: <AdminPanel/>,
          },
          {
              path: "/home",
              element: <Mapa/>,
          }
      ]
  },
]);


function App() {

    const [isAuth, setIsAuth] = useState(false)
    const [curMarker, setCurMarker] = useState(null);
    useEffect(() =>{
        if (localStorage.getItem('token')){
            setIsAuth(true)
        }
    })

  return (
      <CurMarkerLock.Provider value={{
          curMarker,
          setCurMarker
      }}>
          <AuthContext.Provider value={{
              isAuth,
              setIsAuth
          }}>
              <div className='app-container'>
                  <RouterProvider router={router} />
              </div>
          </AuthContext.Provider>
      </CurMarkerLock.Provider>
  );
}

export default App;
