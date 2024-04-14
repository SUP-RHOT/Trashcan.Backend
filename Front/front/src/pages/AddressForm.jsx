import React, {useContext, useState} from 'react';
import "../styles/AddressForm.css"
import {SetByAddress} from "../http/userAPI";
import {useNavigate} from "react-router-dom";


const AddressForm = () => {



        const [city, setCity] = useState('');
        const [street, setStreet] = useState('');
        const [house, setHouse] = useState('');
        const [typeMessage, setTypeMessage] = useState('');
        const [textMessage, setTextMessage] = useState('');
        const navigate = useNavigate()

        const handleSubmit = async (event) => {
            event.preventDefault();
            const ev = {
                    "eventCreateDto": {
                            "status": true,
                            "typeMessage": typeMessage,
                            "textMessage": textMessage,
                            "photo": "string",
                            "date": "2024-04-12T18:12:10.259Z",
                            "result": true,
                            "actorId": JSON.parse(localStorage.getItem('actor')).id,
                            "rubricName": "string",
                            "templateName": "string"
                    },
                    "addressDto": {
                            "city": city,
                            "street": street,
                            "house": house
                    }
            }
            const responce = await SetByAddress(ev)
            console.log(responce)
                navigate('/map')
                alert('точка была успешно создана!')
        };

        return (
            <form className="form-container" onSubmit={handleSubmit}>
                <label htmlFor="city">City:</label>
                <input
                    type="text"
                    id="city"
                    value={city}
                    onChange={(event) => setCity(event.target.value)}
                />
                <br />

                <label htmlFor="street">Street:</label>
                <input
                    type="text"
                    id="street"
                    value={street}
                    onChange={(event) => setStreet(event.target.value)}
                />
                <br />

                <label htmlFor="house">House:</label>
                <input
                    type="text"
                    id="house"
                    value={house}
                    onChange={(event) => setHouse(event.target.value)}
                />
                <br />

                <label htmlFor="typeMessage">Type of message:</label>
                    <input
                        type="text"
                        id="typeMessage"
                        value={typeMessage}
                        onChange={(event) => setTypeMessage(event.target.value)}
                    />
                <br />

                <label htmlFor="textMessage">Message:</label>
                <textarea
                    id="textMessage"
                    value={textMessage}
                    onChange={(event) => setTextMessage(event.target.value)}
                />
                <br />

                <button type="submit">Submit</button>
            </form>
        );
    };


    export default AddressForm;