const fs = require('fs')
const config = require('./config.json')
const { networkInterfaces } = require('os')
const moment = require('moment')

const configIp = () => {
    let net = networkInterfaces()["Wi-Fi"].filter(x => x.family === 'IPv4')[0].address

    if (net !== config.ip) {
        config.ip = net

        fs.writeFileSync('./config.json', JSON.stringify(config, null, 4))
        fs.appendFileSync('./config-ip.log', `IP Updated: ${net} Date: ${moment().format('DD/MM/YYYY - HH:mm')}\n`)
    }
}

configIp()