import React from "react";
import { BrowserRouter as Router, Route, Routes, useNavigate } from 'react-router-dom';
import history from './components/history'; // Correct path to history.js
import "./App.css";

function App() {
  return (
    <Router>
      <div>
        <NavigationButtons />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/purchase" element={<Purchase />} />
          {/* Add more routes as needed */}
        </Routes>
      </div>
    </Router>
  );
}

function NavigationButtons() {
  const navigate = useNavigate(); // Use useNavigate hook

  return (
    <p>
      <button onClick={() => navigate('/login')}>User Giriş Kayıt</button>
      <button onClick={() => navigate('/purchase')}>Satın Alım</button>
    </p>
  );
}

function Home() {
  return <h2>Home Page</h2>;
}

function Login() {
  return <h2>Login Page</h2>;
}

function Purchase() {
  return <h2>Purchase Page</h2>;
}

export default App;
