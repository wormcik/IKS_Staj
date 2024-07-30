import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios'; // Ensure you import axios
import './satinAlim.css';

const SatinAlim = () => {
  const navigate = useNavigate();
  const [talepListesi, setTalepListesi] = useState([]);
  const jwtToken = localStorage.getItem('jwt');

  useEffect(() => {
    const fetchData = async () => {
      try {
        axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
        const response = await axios.post('https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepListele');
        setTalepListesi(response.data.model);
        debugger
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
      <button className="logOutButton" onClick={handleLogOutButtonClick}>G�venli ��k��</button>
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
          {talepListesi?.map((item, index) => (
            <tr key={index}>
              <td>{item.talepTarih}</td>
              <td>{item.aciklama}</td>
              <td>{item.ongorulenTutar}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SatinAlim;
