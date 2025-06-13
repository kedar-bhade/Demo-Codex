import { useState } from "react";
import axios from 'axios';

const RegisterUser = () => {
    const [form, setForm] = useState({username:"", password:""});

    const saveData = (event) => {
        event.preventDefault();
        axios.post('http://localhost:5213/api/auth/register', form);
    };

    const handleChange = (event) => {
        const {name, value} = event.target;
        setForm({...form, [name]: value});
    };

    return (
        <>
            <br/><br/>
            <h4>Register</h4>
            <form onSubmit={saveData}>
                <input type="text" name="username" onChange={handleChange} placeholder="Username" />
                <input type="password" name="password" onChange={handleChange} placeholder="Password" />
                <input type="submit" value="Register" />
            </form>
        </>
    );
};

export default RegisterUser;
