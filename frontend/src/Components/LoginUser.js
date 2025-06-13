import { useState } from "react";
import axios from 'axios';

const LoginUser = () => {
    const [form, setForm] = useState({username:"", password:""});

    const submitData = (event) => {
        event.preventDefault();
        axios.post('http://localhost:5213/api/auth/login', form)
            .then(() => alert('Login success'))
            .catch(() => alert('Login failed'));
    };

    const handleChange = (event) => {
        const {name, value} = event.target;
        setForm({...form, [name]: value});
    };

    return (
        <>
            <br/><br/>
            <h4>Login</h4>
            <form onSubmit={submitData}>
                <input type="text" name="username" onChange={handleChange} placeholder="Username" />
                <input type="password" name="password" onChange={handleChange} placeholder="Password" />
                <input type="submit" value="Login" />
            </form>
        </>
    );
};

export default LoginUser;
