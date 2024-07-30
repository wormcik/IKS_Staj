import React, { useEffect, useState } from "react";
import { Route, Routes, useNavigate} from "react-router-dom";
import SatinAlim from "./components/satinAlim/SatinAlim";
import SatinAlimEkle from "./components/satinAlim/satinAlimEkle";
import UserGirisKayit from "./components/userGirisKayit/UserGirisKayit";
import Temp from "./components/Temp";
import UserGiris from "./components/userGirisKayit/UserGiris";
import UserKayit from "./components/userGirisKayit/UserKayit";
import { jwtDecode } from "jwt-decode";

const AppRoutes = () => {
  const navigation = useNavigate();
const [signed_in,setSigned_in] = useState(false);
  useEffect(() => {
  const a = localStorage.getItem('jwt');
  
  setSigned_in(a != null);
  if(signed_in){
    const jwt = jwtDecode(localStorage.getItem('jwt'));
    const currentTime = Date.now() / 1000;
    /*signed_in = */setSigned_in(jwt.exp < (currentTime));
  }
  if(!signed_in){
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
        {signed_in && <Route exact path="/" element={<Temp />} />}
        <Route exact path="/satinAlim/*" element={<SatinAlim />} />
        {signed_in && <Route exact path="/giris" element={<UserGiris/>} />}
        {signed_in && <Route exact path="/kayit" element = {<UserKayit/>} />} 
        <Route exact path="/kullanici/*" element = {<UserGirisKayit/>}/>
        <Route path = "*" element = {<Temp/>}/>
      </Routes>
    
  );
};

export default AppRoutes;
