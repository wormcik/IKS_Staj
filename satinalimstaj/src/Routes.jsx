import React, { useEffect, useState } from "react";
import { Route, Routes, useNavigate,Navigate } from "react-router-dom";
import SatinAlim from "./components/satinAlim/SatinAlim";
import SatinAlimEkle from "./components/satinAlim/satinAlimEkle";
import Temp from "./components/Temp";
import UserGiris from "./components/userGirisKayit/UserGiris";
import UserKayit from "./components/userGirisKayit/UserKayit";
import TalepEkle from "./components/satinAlim/TalepEkle";
import { jwtDecode } from "jwt-decode";
import { useParams } from "react-router-dom";

const AppRoutes = () => {
  const currentPath = window.location.pathname;
  console.log(currentPath);
  const navigation = useNavigate();
  const [signed_in,setSigned_in] = useState(false);
  useEffect(() => {
  const jwt = localStorage.getItem('jwt');
  if(jwt){
    const jwt = jwtDecode(localStorage.getItem('jwt'));
    const currentTime = Date.now() / 1000;
    if (jwt.exp < currentTime) {
      localStorage.removeItem('jwt');
    }
      else {
        setSigned_in(true);
        if (currentPath === '/giris') {
          navigation('/satinAlim');
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
    {console.log(currentPath, "asdasdsad", signed_in)}
    {signed_in && (
        <>
            <Route exact path="/satinAlim" element={<SatinAlim />} />
            <Route exact path="/" element={<Navigate to="/satinAlim" />} />
            {currentPath === "/satinAlim/ekle" && (
                <Route exact path="/satinAlim/ekle" element={<TalepEkle />} />
            )}
        </>
    )}
    {!signed_in && (
        <>
            <Route exact path="/giris" element={<UserGiris />} />
            <Route exact path="/kayit" element={<UserKayit />} />
            <Route path="/" element={<Navigate to="/giris" />} />
        </>
    )}
</Routes>
    
  );
};

export default AppRoutes;
