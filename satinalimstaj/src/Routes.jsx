import React from "react";
import { Route, Routes } from "react-router-dom";
import SatinAlim from "./components/satinAlim/SatinAlim";
import UserGirisKayit from "./components/userGirisKayit/UserGirisKayit";
import Temp from "./components/Temp";

const AppRoutes = () => {
  return (
  
      <Routes>
        <Route exact path="/" element={<Temp />} />
        <Route exact path="/kullaniciGiris" element={<UserGirisKayit />} />
        <Route exact path="/satinAlim" element={<SatinAlim />} />
      </Routes>
    
  );
};

export default AppRoutes;
