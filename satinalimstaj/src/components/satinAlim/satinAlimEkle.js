import React from 'react';
import { useNavigate } from 'react-router-dom';
import './satinAlimEkle.css';

const SatinAlimEkle = () => {
  const navigate = useNavigate(); // Use the navigate hook to programmatically navigate

  // Function to handle the redirection based on the category
  const handleRedirect = (category) => {
    navigate(`/satinAlim/${category}`);
  };

  return (
    <div className="satinAlimEkleContainer">
      <h1>Satin Alim Talep Ekle</h1>
      <div className="category-list">
        <div 
          className="category-item" 
          onClick={() => handleRedirect('saglik')}
        >
          Sağlık
        </div>
        <div 
          className="category-item" 
          onClick={() => handleRedirect('egitim')}
        >
          Eğitim
        </div>
        <div 
          className="category-item" 
          onClick={() => handleRedirect('kirtasiye')}
        >
          Kırtasiye
        </div>
        <div 
          className="category-item" 
          onClick={() => handleRedirect('teknoloji')}
        >
          Teknoloji
        </div>
      </div>
    </div>
  );
};

export default SatinAlimEkle;
