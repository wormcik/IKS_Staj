import React, { useState } from 'react';
import axios from 'axios';
import UserGirisKayit from './UserGirisKayit';
import { Navigate } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { Route,Routes } from 'react-router-dom';
import SatinAlim from '../satinAlim/SatinAlim';
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
        //const Message = response.data.message;

        if(Success  && Model != null){
        localStorage.setItem('jwt', Model);
        console.log('JWT:', Model);
        //let path = '/KullaniciGiris';
        navigate("/");
        }

      } catch (error) {
        //setError('Failed to sign in. Please check your credentials and try again.');
        console.error('Sign-in error:');
      } 
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="username">Username:</label>
        <input
          type="text"
          id="username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div>
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
    </form>
  );
};


const UserGiris = () => {
  return (
    <div>
      <h1>Sign In</h1>
      <SignInForm /> 
    </div>
  );
};

export default UserGiris;
