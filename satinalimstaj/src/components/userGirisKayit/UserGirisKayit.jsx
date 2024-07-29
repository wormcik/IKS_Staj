import React from "react";
import { Route, Routes } from "react-router-dom";
import UserGiris from "./UserGiris";
import UserGirisHome from "./userGirisHome"

const UserGirisKayit = () => {
  return (
    <Routes>
      <Route exact path="/" element ={<UserGirisHome/>} ></Route>
        <Route exact path = "/giris" element={<UserGiris/>}></Route>
        <Route exact path = "/kayit" element={<UserGiris/>}></Route>
    </Routes>
)
};

export default UserGirisKayit;
