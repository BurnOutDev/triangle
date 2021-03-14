const axios = require('axios').default;
const urljoin = require('url-join');
const Buffer = require('buffer').Buffer

const apiCall = async (host, path, headers, content, method) => {
    const options = {
        method: method,
        headers: headers,
        url: urljoin('https://', host, path),
        data: content
    };
    debugger

    return await new Promise((resolve, reject) => {
        const req = axios.request(options).then((res) => {
            resolve(res.data)
        }).catch(error => {
            debugger
            console.log(error)
        });
    });
};

const generateToken = (options) => {
    const path = '/opay/api/v1/oauth2/token/';
    const queryParams = { grant_type: "client_credentials" };
    const content = Object.keys(queryParams).map(key => `${key}=${queryParams[key]}`).join('&');
    const usernameAndPassword = `${options.username}:${options.password}`;
    const headers = {
        'Content-Type': 'application/x-www-form-urlencoded',
        'Authorization': `Basic ${Buffer.from(usernameAndPassword).toString('base64')}`
    };
    return apiCall(options.api, path, headers, content, 'POST');
};

const checkout = (options, token, checkoutDetails) => {
    const path = '/opay/api/v1/checkout/orders/';
    const content = JSON.stringify(checkoutDetails);
    const headers = {
        'Content-Type': 'application/json',
        'Authorization': `Basic ${token}`
    };
    return apiCall(options.api, path, headers, content, 'POST');
};

const getOrders = (options, token, order) => {
    const path = `/opay/api/v1/checkout/orders/${order}`;
    const headers = {
        'Content-Type': 'application/json',
        'Authorization': `Basic ${token}`
    };
    const content = {};
    return apiCall(options.api, path, headers, JSON.stringify(content), 'GET');
}

module.exports = {
    generateToken,
    checkout,
    getOrders
}