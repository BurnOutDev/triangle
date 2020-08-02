import axios from 'axios';
import { AsyncStorage, DevSettings } from 'react-native';
import MockAdapter from 'axios-mock-adapter'

axios.interceptors.request.use(async (config) => {
    const token = await AsyncStorage.getItem('token')

    config.headers = {
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json'
    }

    config.baseURL = 'http://192.168.43.70:5001/'

    return config;
}, error => {

    return Promise.reject(error);
});

axios.interceptors.response.use((response) => {
    return response;
}, error => {
    if (error ?? error.response ?? error.response.status === 401) {
        AsyncStorage.removeItem('token').then(DevSettings.reload())
    }

    console.log(error)

    return Promise.reject(error);
});

const mock = new MockAdapter(axios, {onNoMatch:'passthrough'})

mock.onGet('/Restaurant/Cuisines').reply(200, require('./Mock/Get/Restaurant/Cuisines.json'))
mock.onPost('/Restaurant/RestaurantsPerCategory').reply(200, require('./Mock/Get/Restaurant/Restaurants.json'))
mock.onGet('/Restaurant/Restaurants').reply(200, require('./Mock/Get/Restaurant/Restaurants.json'))
mock.onGet('/Restaurant/Restaurant/1').reply(200, require('./Mock/Get/Restaurant/Restaurant.json'))
mock.onGet('/Menu/GetMenuItems/').reply(200, require('./Mock/Get/Restaurant/MenuItems.json'))

export default axios