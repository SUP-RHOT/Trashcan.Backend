import {$authHost, $host} from "./index";
import { jwtDecode } from "jwt-decode";

export const registration = async (user) => {
    const responce = await $host.post('api/Auth/register', user)
    return responce
}

export const login = async (login, password) => {
    const responce = await $host.post('api/Auth/login', {login, password})
    localStorage.setItem('token', responce.data.data.accessToken)
    localStorage.setItem('rToken', responce.data.data.refreshToken)
    localStorage.setItem('actorId', responce.data.data.id)
    return responce
}

export const getActor = async (id) => {
    const responce = await $authHost.get('api/v1/Actor/getActor?id=' + id)
    return responce
}

export const deleteEvent = async (id) => {
    const responce = await $authHost.delete('api/Event/deleteEvent?Id=' + id)
    return responce
}

export const getAllEvents = async () => {
    const responce = await $host.get('api/Event/getAll')
    return responce
}

export const check = async () => {
    // const responce = await $authHost.post('api/Auth/refresh')
    // localStorage.setItem('token', responce.data.data.accessToken)
    // localStorage.setItem('rToken', responce.data.data.accessToken)
    // return jwtDecode(responce.data.data.accessToken)
    const accessToken = localStorage.getItem('token')
    const refreshToken = localStorage.getItem('rToken')
    const responce = await $authHost.post('api/Token/refresh', {accessToken, refreshToken})
    localStorage.setItem('token', responce.data.data.accessToken)
    localStorage.setItem('rToken', responce.data.data.refreshToken)
    return responce
}

export const SetByCords = async (object) => {
    const responce = await $host.post('api/Event/createByCoords', object)
    return responce
}

export const SetByAddress = async (object) => {
    const responce = await $host.post('api/Event/createByLocation', object)
    return responce
}