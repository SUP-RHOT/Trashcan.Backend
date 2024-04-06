import React from "react";
import L from 'leaflet';
import {TileLayer, Marker, Popup, MapContainer} from "react-leaflet";
import './styles/Map.css';

// указываем путь к файлам marker
L.Icon.Default.imagePath = "https://unpkg.com/leaflet@1.5.0/dist/images/";

class MapComponent extends React.Component {

    render() {

        let state = {
            lat: 53.225791,
            lng: 50.193672,
            zoom: 10
        };
        function success(pos){
            state.lat = pos.coords.latitude;
            state.lng = pos.coords.longitude;
        }
        function error(){

        }

        navigator.geolocation.watchPosition(success, error);

        let center = [state.lat, state.lng];

        return (
            <MapContainer zoom={state.zoom} center={center}>
                <TileLayer
                    attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />

                <Marker position={center}>
                    <Popup>Владимир Андреевич, вы попопались!!</Popup>
                </Marker>
            </MapContainer>
        );
    }
};

export default MapComponent;