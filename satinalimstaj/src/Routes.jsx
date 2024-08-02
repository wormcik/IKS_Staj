import React, { useEffect, useState } from "react";
import { Route, Routes, useNavigate,Navigate } from "react-router-dom";
import SatinAlim from "./components/satinAlim/SatinAlim";
import SatinAlimEkle from "./components/satinAlim/satinAlimEkle";
import Temp from "./components/Temp";
import UserGiris from "./components/userGirisKayit/UserGiris";
import UserKayit from "./components/userGirisKayit/UserKayit";
import TalepEkle from "./components/satinAlim/TalepEkle";
import TalepDetay from "./components/satinAlim/TalepDetay";
import { jwtDecode } from "jwt-decode";
import SatinAlimTaleplerim from "./components/satinAlim/SatinAlimTaleplerim";
const AppRoutes = () => {
  const navigation = useNavigate();
const [signed_in,setSigned_in] = useState(false);
  useEffect(() => {
  const jwt = localStorage.getItem('jwt');
  if(jwt){
    const currentPath = window.location.pathname;

    const jwt = jwtDecode(localStorage.getItem('jwt'));
    const currentTime = Date.now() / 1000;
    if (jwt.exp < currentTime) {
      localStorage.removeItem('jwt');
    }
      else {
        setSigned_in(true);
        if (currentPath === "/" || currentPath === "/giris" || currentPath === "/kayit") {
          navigation("/satinAlim");
        }
      }
  }
  if(!jwt){
    const currentPath = window.location.pathname;
    if(currentPath != '/kayit')
    navigation('/giris');
    if(currentPath == '/kayit')
    navigation('/kayit');
  }
}
  ,[]);


  return (
      <Routes>
        {signed_in &&  <Route exact path="/satinAlim/" element={<SatinAlim />} />}
        {!signed_in && <Route exact path="/giris" element={<UserGiris/>} />}
        {!signed_in && <Route exact path="/kayit" element = {<UserKayit/>} />} 
        {signed_in &&  <Route exact path="satinAlim/ekle" element = {<TalepEkle/>} />}
        {signed_in &&  <Route exact path="satinAlim/detay/:TalepKod" element = {<TalepDetay/>} />}
        {signed_in &&  <Route exact path="satinAlim/taleplerim" element = {<SatinAlimTaleplerim/>}/>}
      </Routes>
    
  );
};

export default AppRoutes;
