import React from "react";
import { Link } from "react-router-dom";

const Temp = () => {
  return (
    <div>
      <h1>Welcome to the Temp Page</h1>
      <p>This is a temporary page for demonstration purposes.</p>
      <nav>
        <ul>
          <li>
            <Link to="/kullaniciGiris">Go to Kullanici Giris</Link>
          </li>
          <li>
            <Link to="/satinAlim">Go to Satin Alim</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Temp;
