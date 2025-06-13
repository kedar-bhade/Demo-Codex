import { useState } from "react";
import axios from 'axios';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL || 'http://localhost:5213'
});

const SendData = () => {
    const [apiData, setApiData] = useState({ username: "", course: "", purchaseDate: "" });
    const [message, setMessage] = useState("");

    const savedata = async (event) => {
        event.preventDefault();
        try {
            await api.post('/api/users', apiData);
            setMessage('User created');
        } catch (err) {
            setMessage('Failed to create user');
            console.error(err);
        }
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setApiData({ ...apiData, [name]: value });
    };

    return (
        <>
            <br /><br />
            <h4>Add new user</h4>
            <form method="POST" onSubmit={savedata}>
                <input type="text" name="username" onChange={handleChange} placeholder="UserName" />
                <input type="text" name="course" onChange={handleChange} placeholder="Course" />
                <input type="text" name="purchaseDate" onChange={handleChange} placeholder="PurchaseDate" />
                <input type="Submit" />
            </form>
            {message && <p>{message}</p>}
        </>
    );
};
export default SendData;
