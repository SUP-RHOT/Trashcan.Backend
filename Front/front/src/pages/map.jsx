import React, {useContext, useEffect, useState} from "react";
import L from 'leaflet';
import {TileLayer, Marker, Popup, MapContainer, useMapEvents} from "react-leaflet";
import '../styles/Map.css';
import ModalComponent from "../components/Modal";
import {CurMarkerLock} from "../context";
import {getAllEvents} from "../http/userAPI";
import * as events from "events";

// указываем путь к файлам marker
L.Icon.Default.imagePath = "https://unpkg.com/leaflet@1.5.0/dist/images/";

const MapComponent = () => {




    const [maks, setMaks] = useState([])
    const [markers, setMarkers] = useState({
        data:[
            {
                location:[53.225791, 50.193672],
                name: "Макс",
                adress: "",
                description: "Затопило учебники, нужно нырять(("
            },
            {
                location:[53.196748, 50.111749],
                name: "Славик",
                adress: "",
                description: "уронил ключи в общественный туалет, вызывайте спасателей!!!"
            },
            {
                location:[53.234836697261585, 50.23140192031861],
                name: "Тима",
                adress: "",
                description: "отдыхаю))))"
            }
        ]})
    useEffect(() => {
        const getEvents = async() =>{
            const events = await getAllEvents()
            setMaks(events.data.data)
        }
        getEvents()
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

        return (
            <div>
                <>
                    <MapContainer zoom={state.zoom} center={center}>
                        <TileLayer
                            attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                        />
                        <MyComponent/>
                        {markers.data.map((marker) => (
                            <Marker position={marker.location}>
                                <Popup><div className="popup-content">
                                    <h3 className="popup-name">{marker.name}</h3>
                                    <p className="popup-address">Адресс: {marker.adress}</p>
                                    <p className="popup-description">Описание: {marker.description}</p>
                                </div></Popup>
                            </Marker>
                        ))}

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
                    <ModalComponent isOpen={isModalOpen} onClose={handleModalClose} />
                </>
            </div>
        );
};

export default MapComponent;