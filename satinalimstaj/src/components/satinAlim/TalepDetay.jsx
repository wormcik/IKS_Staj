import axios from "axios";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const TalepDetay = () => {
    const { TalepKod } = useParams();
    const talepKod = Number(TalepKod);
    const [Talep, setTalep] = useState(null);
    const jwtToken = localStorage.getItem('jwt');
    const [Personel, setPersonel] = useState(null);
    const [UrunListesi, setUrunListesi] = useState([]);
    const [HizmetListesi, setHizmetListesi] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
                const response = await axios.get(`https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepGetir?talepKod=${talepKod}`);
                setTalep(response.data.model);
                
                const personelResponse = await axios.get('https://localhost:7092/api/v1/satinAlim/Personel/UserPersonelGetir');
                setPersonel(personelResponse.data.model);
                
                const UrunListesiResponse = await axios.post('https://localhost:7092/api/v1/satinAlim/Urun/BirimUrunListele');
                setUrunListesi(UrunListesiResponse.data.model);
                
                const HizmetListesiResponse = await axios.post('https://localhost:7092/api/v1/satinAlim/Hizmet/BirimHizmetListele');
                setHizmetListesi(HizmetListesiResponse.data.model);

            } catch (error) {
                console.error('Fetch data error:', error);
            }
        };
        fetchData();
    }, [talepKod, jwtToken]);

    if (!Talep || !Personel) {
        return <p>No data found.</p>; 
    }

    const formatDate = (dateString) => {
        if (!dateString) return '';
        const date = new Date(dateString);
        const formattedDate = date.toLocaleDateString(); 
        const formattedTime = date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }); 
        return `${formattedDate} ${formattedTime}`;
    };

    const handleOnayla = async () => {
        try {
            axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
            await axios.put(`https://localhost:7092/api/v1/satinAlim/SatinAlim/Onayla`, { talepKod });
            const response = await axios.get(`https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepGetir?talepKod=${talepKod}`);
            setTalep(response.data.model);
        } catch (error) {
            console.error('Onayla error:', error);
        }
    };

    const handleReddet = async () => {
        try {
            axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
            await axios.put(`https://localhost:7092/api/v1/satinAlim/SatinAlim/Reddet`, { talepKod });
            const response = await axios.get(`https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepGetir?talepKod=${talepKod}`);
            setTalep(response.data.model);
        } catch (error) {
            console.error('Reddet error:', error);
        }
    };

    const isActionDisabled = Talep.onaylandi || Talep.reddedildi || Personel.onaySira !== Talep.onaySira;

    const statusText = Talep.onaylandi ? 'Onaylandi' : Talep.reddedildi ? 'Reddedildi' : 'Onay Bekliyor';

    const getTanimForKod = (kod, list) => {
        const item = list.find((i) => i.satinAlmaUrunKod === kod || i.satinAlmaHizmetKod === kod);
        return item ? item.tanim : '';
    };

    return (
        <div className='talep_body'>
            <div className="talep_container">
                <h1>Talep Details</h1>
                <div className="talep_form-group">
                    <label htmlFor="status">Durum:</label>
                    <input
                        type="text"
                        id="status"
                        name="status"
                        value={statusText}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="aciklama">Aciklama:</label>
                    <input
                        type="text"
                        id="aciklama"
                        name="aciklama"
                        value={Talep.aciklama || ''}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="islemTarih">Islem Tarih:</label>
                    <input
                        type="text"
                        id="islemTarih"
                        name="islemTarih"
                        value={formatDate(Talep.islemTarih)}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="onaySira">Onay Sira:</label>
                    <input
                        type="number"
                        id="onaySira"
                        name="onaySira"
                        value={Talep.onaySira || ''}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="ongorulenTutar">Ongorulen Tutar:</label>
                    <input
                        type="text"
                        id="ongorulenTutar"
                        name="ongorulenTutar"
                        value={Talep.ongorulenTutar !== undefined ? Talep.ongorulenTutar : '0'}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="ongorulenTutarPbKod">Ongorulen Tutar Pb Kod:</label>
                    <input
                        type="text"
                        id="ongorulenTutarPbKod"
                        name="ongorulenTutarPbKod"
                        value={Talep.ongorulenTutarPbKod || ''}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="satinAlmaBirim">Satin Alma Birim:</label>
                    <input
                        type="text"
                        id="satinAlmaBirim"
                        name="satinAlmaBirim"
                        value={Talep.birimAd || ''}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group">
                    <label htmlFor="talepTarih">Talep Tarih:</label>
                    <input
                        type="text"
                        id="talepTarih"
                        name="talepTarih"
                        value={formatDate(Talep.talepTarih)}
                        readOnly
                        disabled
                    />
                </div>

                <div className="talep_form-group talep_action-buttons">
                    <button
                        className="talep_submit-button"
                        onClick={handleOnayla}
                        disabled={isActionDisabled}
                        style={{ marginRight: '10px' }}
                    >
                        Onayla
                    </button>
                    <button
                        className="talep_reddet-button"
                        onClick={handleReddet}
                        disabled={isActionDisabled}
                    >
                        Reddet
                    </button>
                </div>

                <h2>Ürün Listesi</h2>
                {Talep.talepUrunListe?.length > 0 ? (
                    <table className="talep_table">
                        <thead>
                            <tr>
                                <th>Ürün</th>
                                <th>Miktar</th>
                                <th>Pb Kod</th>
                                <th>Birim Fiyat</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Talep.talepUrunListe.map((item, index) => (
                                <tr key={index}>
                                    <td>{getTanimForKod(item.satinAlmaUrunKod, UrunListesi)}</td>
                                    <td>{item.miktar}</td>
                                    <td>{item.pbKod}</td>
                                    <td>{item.birimFiyat}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                ) : (
                    <p>Ürün bulunmamaktadir.</p>
                )}

                <h2>Hizmet Listesi</h2>
                {Talep.talepHizmetListe?.length > 0 ? (
                    <table className="talep_table">
                        <thead>
                            <tr>
                                <th>Hizmet</th>
                                <th>Miktar</th>
                                <th>Pb Kod</th>
                                <th>Birim Fiyat</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Talep.talepHizmetListe.map((item, index) => (
                                <tr key={index} >
                                    <td>{getTanimForKod(item.satinAlmaHizmetKod, HizmetListesi)}</td>
                                    <td>{item.miktar}</td>
                                    <td>{item.pbKod}</td>
                                    <td>{item.birimFiyat}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                ) : (
                    <p>Hizmet bulunmamaktadir.</p>
                )}
            </div>
        </div>
    );
};

export default TalepDetay;
