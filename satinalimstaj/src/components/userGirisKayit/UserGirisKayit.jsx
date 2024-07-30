import React from "react";
import { Route, Routes } from "react-router-dom";
import UserGiris from "./UserGiris";


const UserGirisKayit = () => {
  return (
    <Routes>
      <Route exact path="/" element ={<UserGiris/>} ></Route>
    </Routes>
)
};

export default UserGirisKayit;
