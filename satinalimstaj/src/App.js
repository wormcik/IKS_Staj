import React from "react";
import { BrowserRouter } from "react-router-dom";
import "./App.css";
import Routes from "./Routes";

function App() {
  return (
    <BrowserRouter>
      <Routes />
    </BrowserRouter>
  );
}

// function NavigationButtons() {
//   const navigate = useNavigate(); // Use useNavigate hook

//   return (
//     <p>
//       <button onClick={() => navigate('/login')}>User Giriş Kayıt</button>
//       <button onClick={() => navigate('/purchase')}>Satın Alım</button>
//     </p>
//   );
// }

// function Home() {
//   return <h2>Home Page</h2>;
// }

// function Login() {
//   return <h2>Login Page</h2>;
// }

// function Purchase() {
//   return <h2>Purchase Page</h2>;
// }

export default App;
