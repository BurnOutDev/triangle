import axios from 'axios';

export const accessToken = ''

axios.interceptors.request.use(config => {

    config.headers = { Authorization: `Bearer ${accessToken}` }
    config.baseURL = 'https://reserveprojectapi.azurewebsites.net/'

    return config;
}, error => {

    return Promise.reject(error);
});

axios.interceptors.response.use((response) => {

    console.log('Response was received');

    return response;
}, error => {

    return Promise.reject(error);
});

export default axios