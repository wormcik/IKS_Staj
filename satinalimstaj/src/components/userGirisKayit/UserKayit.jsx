import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

    const UserTypeOptions = [
        {value: 'Select User Type',label: 'Select User Type'},
        { value: 'Admin', label: 'Admin' },
        { value: 'Birim', label: 'Birim' },
      ];

const SignUpForm = () => {
  const [Username, setUsername] = useState('');
  const [Password, setPassword] = useState('');
  const [Name , setName] = useState('');
  const [LastName, setLastName] = useState('');  
  const [UserType, setUserType] = useState('');

  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    try{
    event.preventDefault(); 
    console.log('Username:', Username);
    console.log('Name : ',Name);
    console.log('LastName : ',LastName);
    console.log('Password:', Password);
    console.log('User Type:', UserType);
  
    const response = await axios.post("https://localhost:7212/api/v1/yetki/Yetki/SignUp",{
        Username,
        Name,
        LastName,
        Password,
        UserType
    });
    const success = response.data.success;
    if(success){
        try {
            const response = await axios.post('https://localhost:7212/api/v1/yetki/Yetki/SingIn', {
              Username,
              Password
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
    }
    }
    catch (error) {
    //setError('Failed to sign in. Please check your credentials and try again.');
    console.error('Sign-up error:');
    } 


  };


  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="username">Username:</label>
        <input
          type="text"
          id="username"
          value={Username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div>
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          value={Name}
          onChange={(e) => setName(e.target.value)}
          required
        />
      </div>
      <div>
        <label htmlFor="lastname">Lastname:</label>
        <input
          type="text"
          id="lastname"
          value={LastName}
          onChange={(e) => setLastName(e.target.value)}
          required
        />
      </div>
      <div>
        <label htmlFor="password">Password:</label>
        <input
          type="password"
          id="password"
          value={Password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>

      <div>
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



      <button type="submit">Sign In</button>
    </form>
);  
};
 
const UserKayit = () => {
  return (
    <div>
      <h1>Sign Up</h1>
      <SignUpForm /> 
    </div>
  );
}; 

export default UserKayit;