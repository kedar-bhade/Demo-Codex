import { useState } from "react";
import axios from 'axios';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL || 'http://localhost:5213'
});

const UpdateData = () => {
    const [id, setId] = useState({ userId: "" });
    const [apiData, setApiData] = useState({ username: "", course: "", purchaseDate: "" });
    const [message, setMessage] = useState("");

    const savedata = async (event) => {
        event.preventDefault();
        try {
            await api.put(`/api/users/${id.userId}`, apiData);
            setMessage('User updated');
        } catch (err) {
            setMessage('Failed to update user');
            console.error(err);
        }
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setApiData({ ...apiData, [name]: value });
    };

    const handleChangedId = (event) => {
        const { name, value } = event.target;
        setId({ ...id, [name]: value });
    };

    return (
        <>
            <br /><br />
            <h4>Update user</h4>
            <form method="POST" onSubmit={savedata}>
                <input type="text" name="userId" onChange={handleChangedId} placeholder="Id" />
                <input type="text" name="username" onChange={handleChange} placeholder="UserName" />
                <input type="text" name="course" onChange={handleChange} placeholder="Course" />
                <input type="text" name="purchaseDate" onChange={handleChange} placeholder="PurchaseDate" />
                <input type="Submit" value="Update" />
            </form>
            {message && <p>{message}</p>}
        </>
    );
};
export default UpdateData;
