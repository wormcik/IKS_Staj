import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './userGirisKayit.css'; // Correctly import the CSS file
import { Link } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';

const SignInForm = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();
  const handleSubmit = async (event) => {
    event.preventDefault();
    console.log('Username:', username);
    console.log('Password:', password);

    try {
      const response = await axios.post('https://localhost:7212/api/v1/yetki/Yetki/SingIn', {
        username,
        password
      });

      const Success = response.data.success;
      const Model = response.data.model;

      if (Success && Model != null) {
        localStorage.setItem('jwt', Model);
        console.log('JWT:', Model);
         navigate("/satinAlim/");
        window.location.reload();
       
      }
      else {
        alert(response.data.message);
      }

    } catch (error) {
      console.error('Sign-in error:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="user_form">
      <div className="user_form__input">
        <label htmlFor="username">Username:</label>
        <input
          type="text"
          id="username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="password">Password:</label>
        <input
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <button type="submit">Sign In</button>
      <Link to="/kayit">Sign Up</Link>
    </form>
  );
};

const UserGiris = () => {
  return (
    <div className="user_body">
      <div className="user_dynamic_container">
        <div className="user_header">
          <h1>Sign In</h1>
        </div>
        <SignInForm />
      </div>
    </div>
  );
};

export default UserGiris;
