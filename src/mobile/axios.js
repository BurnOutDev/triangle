import axios from 'axios';
import { AsyncStorage, DevSettings } from 'react-native';

axios.interceptors.request.use(async (config) => {
    const token = await AsyncStorage.getItem('token')
    
    config.headers = { 
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json' }
    config.baseURL = 'http://192.168.100.7:5001/'

    return config;
}, error => {

    return Promise.reject(error);
});

axios.interceptors.response.use((response) => {
    return response;
}, error => {
debugger

    AsyncStorage.removeItem('token').then(DevSettings.reload())
   
    return Promise.reject(error);
});

export default axios