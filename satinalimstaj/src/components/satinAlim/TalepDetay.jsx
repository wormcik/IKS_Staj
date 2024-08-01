import axios from "axios";
import { useState } from "react";

const TalepEkle = () => {
    const { id } = useParams();
    const itemId = Number(id);

    const [Talep,setTalep] = useState();

    useEffect(() => {
        const fetchData = async () => {
          try {
            axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
            const TalepResponse = await axios.get('https://localhost:7092/api/v1/satinAlim/SatinAlim/TalepGetir');
            setTalep(TalepResponse.data.model);
          }catch(error){
            console.error('Sign-in error:', error);
          }
          fetchData();
        }
        });
    return();
}

