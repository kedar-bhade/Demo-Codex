import { useState } from "react";
import axios from 'axios';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL || 'http://localhost:5213'
});

const SendData = () => {
    const [apiData, setApiData] = useState({ userId: "" });
    const [message, setMessage] = useState("");

    const deleteStd = async (event) => {
        event.preventDefault();
        try {
            await api.delete(`/api/users/${apiData.userId}`);
            setMessage('User deleted');
        } catch (err) {
            setMessage('Failed to delete user');
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
            <h4>Enter userid to be deleted.</h4>
            <form method="GET" onSubmit={deleteStd}>
                <input type="text" name="userId" onChange={handleChange} placeholder="UserId" />
                <input type="Submit" value="Delete" />
            </form>
            {message && <p>{message}</p>}
        </>
    );
};
export default SendData;
