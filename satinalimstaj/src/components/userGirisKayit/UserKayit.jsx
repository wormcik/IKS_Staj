import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './userGirisKayit.css'; // Correctly import the CSS file
import { Link } from 'react-router-dom';

const UserTypeOptions = [
  { value: 'Select User Type', label: 'Select User Type' },
  { value: 'Admin', label: 'Admin' },
  { value: 'Birim', label: 'Birim' },
];

const SignUpForm = () => {
  const [Username, setUsername] = useState('');
  const [Password, setPassword] = useState('');
  const [Name, setName] = useState('');
  const [LastName, setLastName] = useState('');
  const [UserType, setUserType] = useState('');

  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    console.log('Username:', Username);
    console.log('Name : ', Name);
    console.log('LastName : ', LastName);
    console.log('Password:', Password);
    console.log('User Type:', UserType);

    try {
      const response = await axios.post("https://localhost:7212/api/v1/yetki/Yetki/SignUp", {
        Username,
        Name,
        LastName,
        Password,
        UserType
      });
      const success = response.data.success;
      if (success) {
        try {
          const response = await axios.post('https://localhost:7212/api/v1/yetki/Yetki/SingIn', {
            Username,
            Password
          });

          const Success = response.data.success;
          const Model = response.data.model;

          if (Success && Model != null) {
            localStorage.setItem('jwt', Model);
            console.log('JWT:', Model);
            navigate("/");
          }

        } catch (error) {
          console.error('Sign-in error:', error);
        }
      }
      else{
        alert(response.data.message);
      }
    } catch (error) {
      console.error('Sign-up error:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="user_form">
      <div className="user_form__input">
        <label htmlFor="username">Username:</label>
        <input
          type="text"
          id="username"
          value={Username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          value={Name}
          onChange={(e) => setName(e.target.value)}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="lastname">Lastname:</label>
        <input
          type="text"
          id="lastname"
          value={LastName}
          onChange={(e) => setLastName(e.target.value)}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="password">Password:</label>
        <input
          type="password"
          id="password"
          value={Password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="userType">User Type:</label>
        <select
          id="userType"
          value={UserType}
          onChange={(e) => setUserType(e.target.value)}
          required
        >
          {UserTypeOptions.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>
      </div>
      <button type="submit">Sign Up</button>
      <Link to="/giris">Go to Kullanici Giris</Link>
    </form>
  );
};

const UserKayit = () => {
  return (
    <div className="user_body">
      <div className="user_dynamic_container">
        <div className="user_header">
          <h1>Sign Up</h1>
        </div>
        <SignUpForm />
      </div>
    </div>
  );
};

export default UserKayit;
