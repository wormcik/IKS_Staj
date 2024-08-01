import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './satinAlim.css';

const SatinAlim = () => {
  const navigate = useNavigate();
  const [talepListesi, setTalepListesi] = useState([]);
  const [startDate, setStartDate] = useState('');
  const [minAmount, setMinAmount] = useState('');
  const [endDate, setEndDate] = useState('');
  const [maxAmount, setMaxAmount] = useState('');
  const jwtToken = localStorage.getItem('jwt');

  const handleButtonClick = () => {
    navigate('/satinAlim/ekle');
  };

  const handleLogOutButtonClick = () => {
    localStorage.removeItem('jwt');
    window.location.reload();
  };

  const handleSorgulaClick = async () => {
    try {
      axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
      
      const payload = {
        startDate: startDate || null,
        minAmount: minAmount || null,
        endDate: endDate || null,
        maxAmount: maxAmount || null,
      };
      
      console.log("Request Payload:", payload);
      const response = await axios.post('https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepListele', payload);
      setTalepListesi(response.data.model);
    } catch (error) {
      console.error("Error fetching filtered data:", error);
    }
  };

  return (
    <div className='satinalimcontainer'>
      <button className="addButton" onClick={handleButtonClick}>Ekle</button>
      <button className="logOutButton" onClick={handleLogOutButtonClick}>Güvenli Çıkış</button>
      <h1>Satin Alim</h1>
      <div className='buttonContainer'>
        <div className='leftButtons'>
          <div className='buttonRow'>
            <label>
              <input
                type="text"
                className="actionInput"
                placeholder="Baslangic Tarihi"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
              />
            </label>
            <label>
              <input
                type="text"
                className="actionInput"
                placeholder="Minimum"
                value={minAmount}
                onChange={(e) => setMinAmount(e.target.value)}
              />
            </label>
          </div>
          <div className='buttonRow'>
            <label>
              <input
                type="text"
                className="actionInput"
                placeholder="Bitisi Tarihi"
                value={endDate}
                onChange={(e) => setEndDate(e.target.value)}
              />
            </label>
            <label>
              <input
                type="text"
                className="actionInput"
                placeholder="Maximum"
                value={maxAmount}
                onChange={(e) => setMaxAmount(e.target.value)}
              />
            </label>
          </div>
        </div>
        <div className='rightButton'>
          <button className="newButton" onClick={handleSorgulaClick}>Sorgula</button>
        </div>
      </div>
      <table>
        <thead>
          <tr>
            <th>Talep Tarih</th>
            <th>Öngörülen Tutar</th>
            <th>Öngörülen Tutar Pb Kod</th>
            <th>Açıklama</th>
            <th>Transaction ID</th>
            <th>Onay Sıra</th>
          </tr>
        </thead>
        <tbody>
          {talepListesi?.map((item, index) => (
            <tr key={index}>
              <td>{item.talepTarih}</td>
              <td>{item.ongorulenTutar}</td>
              <td>{item.ongorulenTutarPbKod}</td>
              <td>{item.aciklama}</td>
              <td>{item.transactionId}</td>
              <td>{item.onaySira}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SatinAlim;
