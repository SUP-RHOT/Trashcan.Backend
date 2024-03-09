
import AuthPage from './AuthPage';
import HomePage from './HomePage';
import './styles/App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";

const router = createBrowserRouter([
  {
      path: "/Musorka/",
      element: <HomePage/>,
      children:[
          {
              path: "/Musorka/Auth",
              element: <AuthPage/>,
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
