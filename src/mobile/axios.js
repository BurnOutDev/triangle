import axios from 'axios';
import { AsyncStorage } from 'react-native';

axios.interceptors.request.use(async (config) => {
    const token = await AsyncStorage.getItem('token')
    
    config.headers = { Authorization: `Bearer ${token}` }
    config.baseURL = 'https://reserveprojectapi.azurewebsites.net/'

    return config;
}, error => {

    return Promise.reject(error);
});

axios.interceptors.response.use((response) => {

    console.log('Response was received');
    console.log(response);

    return response;
}, error => {

    return Promise.reject(error);
});

export default axios