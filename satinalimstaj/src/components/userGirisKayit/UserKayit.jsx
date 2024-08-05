import axios from 'axios';
import React, { useState } from 'react';
import './userGirisKayit.css'; // Correctly import the CSS file
import { Link } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';
import { useEffect } from 'react';
import { v4 as uuidv4 } from 'uuid';

const SignUpForm = (props) => {
  const [BirimData, setBirimData] = useState([]);
  const [kayitModel, setKayitModel] = useState({});
  const [personelKayitModel, setPersonelKayitModel] = useState({
    ad: null,
    soyad: null,
    pozisyon: null,
    satinAlmaBirimKod: 1,
    userName: null,
  });


  useEffect(() => {
    if (BirimData.length > 0) {
      return;
    }
    const fetchBirimData = async () => {
      try {
        const response = await axios.post('https://localhost:7092/api/v1/satinAlim/Birim/BirimListele',{}) ;
        
        if (response?.data?.success) {
          setBirimData(response.data.model);
        } else {
          alert(response?.data?.message);
        }
      } catch (error) {
        console.error('Error fetching Birim data:', error);
        alert('An error occurred while fetching Birim data.');
      }
    };

    fetchBirimData();
  }, []);


    

  const handleSubmit = async (event) => {
    try {
      let eklenecekUser = {
        userName: kayitModel.userName,
        name: kayitModel.name,
        lastName: kayitModel.lastName,
        password: kayitModel.password,
        userType: "Birim"
      }

      const response = await axios.post("https://localhost:7212/api/v1/yetki/Yetki/SignUp", eklenecekUser);

      const success = response.data.success;
      if (success) {
        try {
          const response = await axios.post('https://localhost:7212/api/v1/yetki/Yetki/SingIn', {
            userName: eklenecekUser.userName,
            password: eklenecekUser.password
          });

          const Success = response.data.success;
          const Model = response.data.model;

          if (Success && Model != null) {
            localStorage.setItem('jwt', Model);
            console.log('JWT:', Model);
            const jwt = Model
            let eklenecekPersonel = {
              ad: personelKayitModel.ad,
              soyad: personelKayitModel.soyad,
              pozisyon: personelKayitModel.pozisyon,
              satinAlmaBirimKod: parseInt(personelKayitModel.satinAlmaBirimKod),
              kullaniciKod: uuidv4(jwtDecode(jwt).KullaniciKod)
            }
            try {
              axios.defaults.headers.common['Authorization'] = `Bearer ${jwt}`;
              const response = await axios.post("https://localhost:7092/api/v1/satinAlim/Personel/PersonelEkle", eklenecekPersonel);

            }
            catch (error) {
              console.error('Personel error:', error);
            }
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
        <label htmlFor="userName">Username:</label>
        <input
          type="text"
          id="userName"
          value={kayitModel.userName}
          onChange={(e) => {setKayitModel({ ...kayitModel, userName: e.target.value });
            
          }}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          value={kayitModel.name}
          onChange={(e) => {setKayitModel({ ...kayitModel, name: e.target.value });
           setPersonelKayitModel({ ...personelKayitModel, ad: e.target.value });
          }}          
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="lastName">Lastname:</label>
        <input
          type="text"
          id="lastName"
          value={kayitModel.lastName}
          onChange={(e) => {setKayitModel({ ...kayitModel, lastName: e.target.value });
          setPersonelKayitModel({ ...personelKayitModel, soyad: e.target.value });
          }}
          required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="password">Password:</label>
        <input
          type="password"
          id="password"
          value={kayitModel.password}
          onChange={(e) => {setKayitModel({ ...kayitModel, password: e.target.value });
          }}
        required
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="pozisyon">Ünvan:</label>
        <input
          type="pozisyon"
          id="pozisyon"
          value={personelKayitModel.pozisyon}
          onChange={(e) => {setPersonelKayitModel({ ...personelKayitModel, pozisyon: e.target.value });
          }}
        />
      </div>
      <div className="user_form__input">
        <label htmlFor="Pozisyon">Birim :</label>
        <select
          id="pozisyon"
          value={personelKayitModel.satinAlmaBirimKod ?? null}
          onChange={(e) => {
            setPersonelKayitModel({ ...personelKayitModel, satinAlmaBirimKod: e.target.value});
          }}
          required
        >
          {BirimData?.map((option) => (
            <option value={option.satinAlmaBirimKod}>
              {option.birimAd}
            </option>
          ))}
        </select>
      </div>
      <button type="submit">Sign Up</button>
      <Link to="/giris">Sign In</Link>
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
