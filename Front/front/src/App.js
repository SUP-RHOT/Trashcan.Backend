
import AuthPage from './AuthPage';
import HomePage from './HomePage';
import RegistrationForm from './pages/RegistrationPage';
import './styles/App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";

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
  return (
    <div className='app-container'>
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
