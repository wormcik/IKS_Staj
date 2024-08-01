import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './satinAlim.css';

const TalepEkle = () => {
  const navigate = useNavigate();
  const [urunListesi, setUrunListesi] = useState([]);
  const [HizmetListesi, setHizmetListesi] = useState([]);
  const [BirimData, setBirimData] = useState([]);
  const [selectedBirimAd, setSelectedBirimAd] = useState(null);
  const [selectedUrun, setSelectedUrun] = useState(null);
  const [selectedHizmet, setSelectedHizmet] = useState(null);
  const [formData, setFormData] = useState({
    satinAlmaBirimKod: 0, 
    ongorulenTutar: 0,
    ongorulenTutarPbKod: '',
    aciklama: '',
    miktar: '',
    birimFiyat: '',
    
    talepUrunSorguModelListe: [],
    talepHizmetSorguModelListe: []
  });
  const [currentItem, setCurrentItem] = useState({});
  const jwtToken = localStorage.getItem('jwt');

  useEffect(() => {
    const fetchData = async () => {
      try {
        axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
        const UrunResponse = await axios.post('https://localhost:7092/api/v1/satinAlim/Urun/BirimUrunListele');
        setUrunListesi(UrunResponse.data.model);

        const HizmetResponse = await axios.post('https://localhost:7092/api/v1/satinAlim/Hizmet/BirimHizmetListele');
        setHizmetListesi(HizmetResponse.data.model);

        const response = await axios.post('https://localhost:7092/api/v1/satinAlim/Birim/BirimListele', {});
        if (response?.data?.success) {
          setBirimData(response.data.model);
        } else {
          alert(response?.data?.message);
        }
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [jwtToken]);

  useEffect(() => {
    const updateSatinAlmaBirimKod = () => {
      if (formData.talepUrunSorguModelListe.length > 0) {
        setFormData(prevState => ({
          ...prevState,
          satinAlmaBirimKod: formData.talepUrunSorguModelListe[0].satinAlmaBirimKod
        }));
      } else if (formData.talepHizmetSorguModelListe.length > 0) {
        setFormData(prevState => ({
          ...prevState,
          satinAlmaBirimKod: formData.talepHizmetSorguModelListe[0].satinAlmaBirimKod
        }));
      }
    };

    updateSatinAlmaBirimKod();
  }, [formData.talepUrunSorguModelListe, formData.talepHizmetSorguModelListe]);

  const handleButtonClick = (birimAd) => {
    setSelectedBirimAd(birimAd);
    setSelectedUrun(null); 
    setSelectedHizmet(null); 
  };

  const handleUrunButtonClick = (urun) => {
    setSelectedUrun(urun);
    setSelectedHizmet(null); 
    setCurrentItem({
      satinAlmaBirimKod: urun.satinAlmaBirimKod,
      satinAlmaUrunKod: urun.satinAlmaUrunKod,
      miktar: '',
      pbKod: '',
      birimFiyat: ''
    });
  };

  const handleHizmetButtonClick = (hizmet) => {
    setSelectedHizmet(hizmet);
    setSelectedUrun(null); 
    setCurrentItem({
      satinAlmaBirimKod: hizmet.satinAlmaBirimKod,
      satinAlmaHizmetKod: hizmet.satinAlmaHizmetKod,
      miktar: '',
      pbKod: '',
      birimFiyat: ''
    });
  };

  const filteredUrunListesi = selectedBirimAd 
    ? urunListesi.filter(urun => urun.birimAd === selectedBirimAd)
    : [];

  const filteredHizmetListesi = selectedBirimAd 
    ? HizmetListesi.filter(hizmet => hizmet.birimAd === selectedBirimAd)
    : [];

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleCurrentItemChange = (e) => {
    const { name, value } = e.target;
    setCurrentItem(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleAddItem = () => {
    if (selectedUrun) {
      setFormData(prevState => ({
        ...prevState,
        talepUrunSorguModelListe: [...prevState.talepUrunSorguModelListe, currentItem]
      }));
    } else if (selectedHizmet) {
      setFormData(prevState => ({
        ...prevState,
        talepHizmetSorguModelListe: [...prevState.talepHizmetSorguModelListe, currentItem]
      }));
    }
    setCurrentItem({});
    setSelectedUrun(null);
    setSelectedHizmet(null);
  };
  const handleSubmit = async (e) => {
    e.preventDefault();
    
    try {
      axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
      const talepResponse = await axios.post('https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepEkle', formData);
      console.log('Talep response:', talepResponse.data);
    } catch (error) {
      console.error('An error occurred while submitting the form:', error);
      alert('An error occurred while submitting the form. Please try again.');
    }
  };
  

  const isBirimButtonsDisabled = () =>
    formData.talepUrunSorguModelListe.length > 0 || formData.talepHizmetSorguModelListe.length > 0;

  return (
    <div>
      <h1>Birim Listesi</h1>
      <div className="birim-listesi">
        {BirimData.map((item, index) => (
          <div key={index} style={{ marginBottom: '10px' }}>
            <button 
              onClick={() => handleButtonClick(item.birimAd)} 
              disabled={isBirimButtonsDisabled()}
            >
              {item.birimAd}
            </button>
          </div>
        ))}
      </div>

      <h2>Ürün Listesi for {selectedBirimAd}</h2>
      <div className="urun-listesi">
        {filteredUrunListesi.length > 0 ? (
          filteredUrunListesi.map((urun, index) => (
            <div key={index} style={{ marginBottom: '10px' }}>
              <button 
                onClick={() => handleUrunButtonClick(urun)} 
                disabled={false} 
              >
                {urun.tanim}
              </button>
            </div>
          ))
        ) : (
          <p>No products available for the selected Birim.</p>
        )}
      </div>

      <h2>Hizmet Listesi for {selectedBirimAd}</h2>
      <div className="hizmet-listesi">
        {filteredHizmetListesi.length > 0 ? (
          filteredHizmetListesi.map((hizmet, index) => (
            <div key={index} style={{ marginBottom: '10px' }}>
              <button 
                onClick={() => handleHizmetButtonClick(hizmet)} 
                disabled={false} 
              >
                {hizmet.tanim}
              </button>
            </div>
          ))
        ) : (
          <p>No services available for the selected Birim.</p>
        )}
      </div>

      {(selectedUrun || selectedHizmet) && (
        <div>
          <h2>Add {selectedUrun ? 'Ürün' : 'Hizmet'} Details</h2>
          <div className="form-group">
            <label htmlFor="miktar">Miktar:</label>
            <input
              type="number"
              id="miktar"
              name="miktar"
              value={currentItem.miktar || ''}
              onChange={handleCurrentItemChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="pbKod">Pb Kod:</label>
            <input
              type="text"
              id="pbKod"
              name="pbKod"
              value={currentItem.pbKod || ''}
              onChange={handleCurrentItemChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="birimFiyat">Birim Fiyat:</label>
            <input
              type="number"
              id="birimFiyat"
              name="birimFiyat"
              value={currentItem.birimFiyat || ''}
              onChange={handleCurrentItemChange}
              required
            />
          </div>
          <button onClick={handleAddItem}>Add to List</button>
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <h2>General Form Details</h2>
        <div className="form-group">
          <label htmlFor="ongorulenTutar">Ongorulen Tutar:</label>
          <input
            type="text"
            id="ongorulenTutar"
            name="ongorulenTutar"
            value={formData.ongorulenTutar}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="ongorulenTutarPbKod">Ongorulen Tutar Pb Kod:</label>
          <input
            type="text"
            id="ongorulenTutarPbKod"
            name="ongorulenTutarPbKod"
            value={formData.ongorulenTutarPbKod}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="aciklama">Aciklama:</label>
          <input
            type="text"
            id="aciklama"
            name="aciklama"
            value={formData.aciklama}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="miktar">Miktar:</label>
          <input
            type="number"
            id="miktar"
            name="miktar"
            value={formData.miktar}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="birimFiyat">Birim Fiyat:</label>
          <input
            type="number"
            id="birimFiyat"
            name="birimFiyat"
            value={formData.birimFiyat}
            onChange={handleInputChange}
            required
          />
        </div>
        <button type="submit">Submit</button>
      </form>

      <div>
        <h2>Ürün List</h2>
        {formData.talepUrunSorguModelListe.length > 0 && (
          <ul>
            {formData.talepUrunSorguModelListe.map((item, index) => (
              <li key={index}>
                Ürün Kod: {item.satinAlmaUrunKod}, Miktar: {item.miktar}, Pb Kod: {item.pbKod}, Birim Fiyat: {item.birimFiyat}
              </li>
            ))}
          </ul>
        )}
        <h2>Hizmet List</h2>
        {formData.talepHizmetSorguModelListe.length > 0 && (
          <ul>
            {formData.talepHizmetSorguModelListe.map((item, index) => (
              <li key={index}>
                Hizmet Kod: {item.satinAlmaHizmetKod}, Miktar: {item.miktar}, Pb Kod: {item.pbKod}, Birim Fiyat: {item.birimFiyat}
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
};

export default TalepEkle;
