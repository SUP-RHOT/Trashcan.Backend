import {$host} from "./index";

export const registration = async (lastName, firstName, secondName, login, password, phoneNumber, email, city, street, house, apartment) => {
    const responce = await $host.post('api/Auth/register', {lastName, firstName, secondName, login, password, phoneNumber, email, city, street, house, apartment})
    return responce
}

export const login = async (email, password) => {
    const responce = await $host.post('api/Auth/login', {email, password})
    return responce
}

export const check = async () => {
    const responce = await $host.post('api/Auth/refresh')
    return responce
}