import React from "react";
import { Route, Routes } from "react-router-dom";
import SatinAlim from "./components/satinAlim/SatinAlim";
import UserGirisKayit from "./components/userGirisKayit/UserGirisKayit";
import Temp from "./components/Temp";
import UserGiris from "./components/userGirisKayit/UserGiris";
import UserKayit from "./components/userGirisKayit/UserKayit";

const AppRoutes = () => {
  return (
  
      <Routes>
        <Route exact path="/" element={<Temp />} />
        <Route exact path="/kullanici/*" element={<UserGirisKayit />} />
        <Route exact path="/satinAlim/*" element={<SatinAlim />} />
        <Route exact path="/kullanici/giris/*" element={<UserGiris/>} />
        <Route exact path="/kullanici/kayit/*" element = {<UserKayit/>} />
      </Routes>
    
  );
};

export default AppRoutes;
