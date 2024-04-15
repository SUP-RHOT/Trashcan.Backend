import React, { useEffect, useState } from 'react';
import '../styles/EventsTable.css';
import {deleteEvent, getAllEvents} from "../http/userAPI";

const EventTable = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        // Replace this with your actual API call
        const fetchData = async () => {
            const response = await getAllEvents();
            setData(response.data.data);
        };
try {
    fetchData();
}catch (e){
    console.log(e)
}

    }, []);


    const handleDelete = async (id) => {
        const responce = await deleteEvent(id)
        console.log(responce)
        setData(data.filter((item) => item.id !== id));
    };

    return (
        <table className="table">
            <thead>
            <tr>
                <th>Type</th>
                <th>Message</th>
                <th>Photo</th>
                <th>Date</th>
                <th>Longitude</th>
                <th>Width</th>
                <th>City</th>
                <th>Street</th>
                <th>House</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {data.map((item) => (
                <tr key={item.date}>
                    <td>{item.typeMessage}</td>
                    <td>{item.textMessage}</td>
                    <td>{item.photo}</td>
                    <td>{item.date}</td>
                    <td>{item.address.longitude || '-'}</td>
                    <td>{item.address.width || '-'}</td>
                    <td>{item.address.city || '-'}</td>
                    <td>{item.address.street || '-'}</td>
                    <td>{item.address.house || '-'}</td>
                    <td>
                        <button onClick={() => handleDelete(item.id)}>Delete</button>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
};

export default EventTable;
