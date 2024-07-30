import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios'; // Ensure you import axios
import './satinAlim.css';

const SatinAlim = () => {
  const navigate = useNavigate();
  const [talepListesi, setTalepListesi] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepListele');
        setTalepListesi(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  const handleButtonClick = () => {
    navigate('/satinAlim/ekle');
  }
  const handleLogOutButtonClick = () =>
  {
    localStorage.removeItem('jwt');
    window.location.reload();
  }
  return (
    <div className='satinalimcontainer'>
      <button className="addButton" onClick={handleButtonClick} >Ekle</button>
      <button className="logOutButton" onClick={handleLogOutButtonClick}>Güvenli Çýkýþ</button>
      <h1>Satin Alim</h1>
      <table>
        <thead>
          <tr>
            <th>Tarih</th>
            <th>Ad</th>
            <th>Miktar</th>
          </tr>
        </thead>
        <tbody>
          {talepListesi.map((item, index) => (
            <tr key={index}>
              <td>{item.tarih}</td>
              <td>{item.ad}</td>
              <td>{item.miktar}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SatinAlim;
