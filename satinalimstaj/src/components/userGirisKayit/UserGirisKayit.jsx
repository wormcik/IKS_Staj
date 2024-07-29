import React from "react";
import { Route, Routes } from "react-router-dom";
import UserGiris from "./UserGiris";
import UserGirisHome from "./userGirisHome"

const UserGirisKayit = () => {
  return (
    <Routes>
      <Route exact path="/" element ={<UserGirisHome/>} ></Route>
        <Route exact path = "/KullaniciGiris2" element={<UserGiris/>}></Route>
        <Route exact path = "/KullaniciKayit" element={<UserGiris/>}></Route>
    </Routes>
)
};

export default UserGirisKayit;
