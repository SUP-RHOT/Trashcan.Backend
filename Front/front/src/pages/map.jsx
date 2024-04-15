import React, {useContext, useEffect, useState} from "react";
import L from 'leaflet';
import {TileLayer, Marker, Popup, MapContainer, useMapEvents} from "react-leaflet";
import '../styles/Map.css';
import ModalComponent from "../components/Modal";
import {CurMarkerLock} from "../context";
import {getAllEvents} from "../http/userAPI";
import * as events from "events";
import {useNavigate} from "react-router-dom";

// указываем путь к файлам marker
L.Icon.Default.imagePath = "https://unpkg.com/leaflet@1.5.0/dist/images/";

const MapComponent = () => {



    const navigate = useNavigate()
    const [maks, setMaks] = useState([])

    useEffect(() => {
        const getEvents = async() =>{
            const events = await getAllEvents()
            setMaks(events.data.data)
        }
        try {
            getEvents()
        } catch (e){
            console.log(e)
        }

    }, []);
    const {curMarker, setCurMarker} = useContext(CurMarkerLock)

        function MyComponent() {
            const map = useMapEvents({
                click: (e) => {
                    map.locate()
                    console.log('тынкул сюда: ', e)
                    //setMarkers({data: [...markers.data, {location: [e.latlng.lat, e.latlng.lng], popup: "click"}]})
                    setCurMarker({longitude:e.latlng.lng, width:e.latlng.lat})
                }
            })
            return null
        }

        let state = {
            lat: 53.225791,
            lng: 50.193672,
            zoom: 10
        };

        let center = [state.lat, state.lng];

    const [isModalOpen, setIsModalOpen] = useState(false);

    const handleMarkerClick = (e) => {
        setIsModalOpen(true);
    };

    const handleModalClose = () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        navigate('/home')
    };

        return (
            <div>
                <>
                    <MapContainer zoom={state.zoom} center={center}>
                        <TileLayer
                            attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                        />
                        <MyComponent/>

                        {maks.map((marker) => (
                            <Marker position={[marker.address?.width ?? 0, marker.address?.longitude ?? 0]}>
                                <Popup><div className="popup-content">
                                    <h3 className="popup-name">{marker.typeMessage}</h3>
                                    <p className="popup-description">Описание: {marker.textMessage}</p>
                                </div></Popup>
                            </Marker>
                        ))}

                        {curMarker == null ? null :
                            <Marker position={[curMarker.width, curMarker.longitude]}>
                            <Popup><button onClick={handleMarkerClick}>Выбрать</button></Popup>
                            </Marker>}

                    </MapContainer>
                    <button className="cancel-button" onClick={handleCancel}>Назад</button>
                    <ModalComponent isOpen={isModalOpen} onClose={handleModalClose} />
                </>
            </div>
        );
};

export default MapComponent;