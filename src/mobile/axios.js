import axios from 'axios';
import { DevSettings } from 'react-native';
import MockAdapter from 'axios-mock-adapter'
import AsyncStorage from '@react-native-community/async-storage'
import { axiosLog, ip } from './config.json'
import { logger } from 'react-native-logs'
import { colorConsoleSync } from 'react-native-logs/dist/transports/colorConsoleSync';
import log from './log'

axios.interceptors.request.use(async (config) => {  
    const token = await AsyncStorage.getItem('token')

    config.headers = {
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json'
    }

    config.baseURL = `http://${ip}:5001/`

    log.apiRequest(config.url)

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

    log.error(error)

    return Promise.reject(error);
});

const logRequest = ({ url }) => {
    !fs.existsSync(`./logs/${axiosLog}`) && fs.writeFileSync(`./logs/${axiosLog}`)
    fs.appendFileSync(`./logs/${axiosLog}`, `Url: ${url} Date: ${moment().format('DD/MM/YYYY - HH:mm')}\n`)
}

const mock = new MockAdapter(axios, { onNoMatch: 'passthrough' })

// mock.onGet('/Restaurant/Cuisines').reply(200, require('./Mock/Get/Restaurant/Cuisines.json'))
// mock.onPost('/Restaurant/RestaurantsPerCategory').reply(200, require('./Mock/Get/Restaurant/Restaurants.json'))
// mock.onGet('/Restaurant/Restaurants').reply(200, require('./Mock/Get/Restaurant/Restaurants.json'))
// mock.onGet('/Restaurant/Restaurant/1').reply(200, require('./Mock/Get/Restaurant/Restaurant.json'))
// mock.onGet('/Menu/GetMenuItems/1').reply(200, require('./Mock/Get/Restauarant/MenuItems.json'))

export default axios