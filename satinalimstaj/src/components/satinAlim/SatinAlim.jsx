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

  const handleTaleplerimClick = () => {
    navigate('/satinAlim/taleplerim');
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

  const handleCellButtonClick = (talepKod) => {
    navigate(`/satinAlim/detay/${talepKod}`);
  };

  const formatDate = (dateString) => {
    const [datePart] = dateString.split('T');
    const [year, month, day] = datePart.split('-');
    return `${day}.${month}.${year}`;
  };

  function booleanToString(bool) {
    if(bool == true)
      return "evet";
    else
      return "yanlış";
  }
  

  const getRowClass = (item) => {
    if (item.talepUrunListe.length > 0) return 'urunRow'; // Ensure item.talepUrunListe exists
    if (item.talepHizmetListe.length > 0) return 'hizmetRow'; // Ensure item.talepHizmetListe exists
    return '';
  };

  useEffect(() => {handleSorgulaClick()},[jwtToken]);




  return (
    <div className='satinalimcontainer'>
      <div className='buttonWrapper'>
        <div className='buttonContainer'>
          <button className="taleplerimButton" onClick={handleTaleplerimClick}>Taleplerim</button>

          <button className="addButton" onClick={handleButtonClick}>Ekle</button>
          <button className="logOutButton" onClick={handleLogOutButtonClick}>Güvenli Çıkış</button>
        </div>
      </div>
      <h1>Satin Alim</h1>
      <div className='buttonContainer'>
        <div className='leftButtons'>
          <div className='buttonRow'>
            <label>
              <input
                type="date"
                className="actionInput"
                placeholder="Baslangic Tarihi"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
              />
            </label>
            <label>
              <input
                type="date"
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
                placeholder="Minimum"
                value={minAmount}
                onChange={(e) => setMinAmount(e.target.value)}
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
          <div className='buttonRow'>

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
            <th>Onaylandı</th>
            <th>Reddedildi</th>
            <th>Onay Sıra</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {talepListesi?.map((item, index) => (
            <tr key={index} style={{ textAlign:'center', backgroundColor: item.talepHizmetListe.length > 0 ? "#32C7C7" : "#FFD700" }}>
              <td>{formatDate(item.talepTarih)}</td>
              <td>{item.ongorulenTutar}</td>
              <td>{item.ongorulenTutarPbKod}</td>
              <td>{item.aciklama}</td>
              <td>{booleanToString(item.onaylandi)}</td>
              <td>{booleanToString(item.reddedildi)}</td>
              <td>{item.onaySira}</td>
              <td>
                <button className="tableButton" onClick={() => handleCellButtonClick(item.satinAlmaTalepKod)}>Detay</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SatinAlim;
  