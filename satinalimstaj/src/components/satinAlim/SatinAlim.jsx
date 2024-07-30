import React from 'react';
import { useNavigate } from 'react-router-dom';
import './satinAlim.css';

const SatinAlim = () => {

  const navigate = useNavigate();
  const talepListesi = [
    { tarih: '2024-07-01', ad: 'Ürün A', miktar: 10 },
    { tarih: '2024-07-02', ad: 'Ürün B', miktar: 5 },
    { tarih: '2024-07-03', ad: 'Ürün C', miktar: 12 },
    { tarih: '2024-07-04', ad: 'Ürün D', miktar: 7 },
    { tarih: '2024-07-05', ad: 'Ürün E', miktar: 20 },
    { tarih: '2024-07-06', ad: 'Ürün F', miktar: 15 },
    { tarih: '2024-07-07', ad: 'Ürün G', miktar: 8 },
    { tarih: '2024-07-08', ad: 'Ürün H', miktar: 25 },
    { tarih: '2024-07-09', ad: 'Ürün I', miktar: 30 },
    { tarih: '2024-07-10', ad: 'Ürün J', miktar: 22 }
  ];

  const handleButtonClick = () =>
  {
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
      <button className="logOutButton" onClick={handleLogOutButtonClick}>Güvenli Çıkış</button>
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
