import React from "react";
import { Link } from "react-router-dom";

const Temp = () => {
  return (
    <div>
      <h1>Welcome to the Temp Page (User Giris)</h1>
      <p>This is a temporary page for demonstration purposes.</p>
      <nav>
        <ul>
          <li>
            <Link to="/KullaniciGiris2">Go to Kullanici Giris</Link>
          </li>
          <li>
            <Link to="/KullaniciKayit">Go to Kullanici Kayit</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Temp;