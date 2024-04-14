import React, {useContext, useEffect, useState} from 'react';
import { Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "../styles/Modal.css"

import {CurMarkerLock, markersContext} from "../context";
import {SetByCords} from "../http/userAPI";

// const updateEventDto = (key, value) => {
//     setEvent(prevEvent => ({
//         ...prevEvent,
//         [key]: value
//     }));
// };
//
// const updateAddressDto = (key, value) => {
//     setEvent(prevEvent => ({
//         ...prevEvent,
//         [key]: value
//     }));
// };


const ModalComponent = ({ isOpen, onClose }) => {

    const {curMarker, setCurMarker} = useContext(CurMarkerLock)

    const [event, setEvent] = useState({
        "eventCreateDto": {
            "status": true,
            "typeMessage": "string",
            "textMessage": "string",
            "photo": "string",
            "date": "2024-04-11T12:46:01.773Z",
            "result": true,
            "actorId": 1,
            "rubricName": "string",
            "templateName": "string"
        },
        "addressDto": {
            "longitude": 0,
            "width": 0
        }
    })
    useEffect(() => {
        const actor = JSON.parse(localStorage.getItem('actor'))
        if (actor){
            updateActorId(actor.id)
        }
    }, []);
    useEffect(() => {
        updateAddressDto(curMarker)

        // Очистка эффекта.
        return () => {
            // Очистка эффекта, если это необходимо.
        };
    }, [curMarker]);
    const updateTypeMessage = (newTypeMessage) => {
        setEvent((prevEvent) => ({
            ...prevEvent,
            eventCreateDto: {
                ...prevEvent.eventCreateDto,
                typeMessage: newTypeMessage,
            },
        }));
    };

    const updateTextMessage = (newTextMessage) => {
        setEvent((prevEvent) => ({
            ...prevEvent,
            eventCreateDto: {
                ...prevEvent.eventCreateDto,
                textMessage: newTextMessage,
            },
        }));
    };

    const updateRubricName = (rubricName) => {
        setEvent((prevEvent) => ({
            ...prevEvent,
            eventCreateDto: {
                ...prevEvent.eventCreateDto,
                rubricName: rubricName,
            },
        }));
    };

    const updateAddressDto = (newAddressDto) => {
        setEvent((prevEvent) => ({
            ...prevEvent,
            addressDto: newAddressDto,
        }));
    };
    const updateActorId = (newActorId) => {
        setEvent((prevEvent) => ({
            ...prevEvent,
            eventCreateDto: {
                ...prevEvent.eventCreateDto,
                actorId: newActorId,
            },
        }));
    };

    //const [markers, setMarkers] = useContext(markersContext)
    const handleSubmit = async() => {
        const responce = await SetByCords(event)
        //setMarkers({data: [...markers.data, {location:curMarkerLock, name:JSON.parse(localStorage.getItem('actor')).name, address:address, description:description}]}))
        onClose();
    };

    return (
            <Modal isOpen={isOpen} toggle={onClose} className="modal-wrapper">
                {localStorage.getItem('actor') ? <div className="modal">
                    <ModalBody>
                        <input
                            type="text"
                            placeholder="введите тему"
                            value={event.eventCreateDto.typeMessage}
                            onChange={(e) => updateTypeMessage(e.target.value)}
                        />
                        <input
                            type="text"
                            placeholder="опишите ситуацию"
                            value={event.eventCreateDto.textMessage}
                            onChange={(e) => updateTextMessage(e.target.value)}
                        />
                        <select className="dropdown" onChange={(e) => updateRubricName(e.target.value)}>
                            <option value="">Select an option</option>
                            <option value="string">string</option>

                        </select>
                    </ModalBody>
                    <ModalFooter>
                        <button color="primary" onClick={handleSubmit}>
                            принять
                        </button>
                        <button color="secondary" onClick={onClose}>
                            отмена
                        </button>
                    </ModalFooter>
                </div> : <div className="modal">
                    <ModalBody>
                        <div>Пожалуйста, авторизируйтесь что бы оставить метку.</div>
                    </ModalBody>
                    <ModalFooter>
                        <button color="secondary" onClick={onClose}>
                            Cancel
                        </button>
                    </ModalFooter>
                </div>}

            </Modal>
    );
};

export default ModalComponent;
