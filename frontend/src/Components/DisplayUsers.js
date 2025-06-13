import { useEffect, useState } from "react";
import axios from 'axios';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL || 'http://localhost:5213'
});

const DisplayData = () => {
    const [apiData, setApiData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.get('/api/users');
                setApiData(response.data);
            } catch (err) {
                console.error(err);
            }
        };
        fetchData();
    }, []);

    const tablerows = apiData.map(obj => (
        <tr key={obj.userId}>
            <td>{obj.userId}</td>
            <td>{obj.username}</td>
            <td>{obj.course}</td>
            <td>{obj.purchaseDate}</td>
        </tr>
    ));

    return (
        <>
            <br /><br />
            <table id="studentsTable">
                <thead>
                    <tr>
                        <td>UserId</td>
                        <td>Username</td>
                        <td>Course</td>
                        <td>PurchaseDate</td>
                    </tr>
                </thead>
                <tbody>{tablerows}</tbody>
            </table>
        </>
    );
};
export default DisplayData;
