const fs = require('fs')
const config = require('./config.json')
const { networkInterfaces } = require('os')
const moment = require('moment')
const { red, blue } = require('chalk')

const configIp = () => {
    const name = "wlp2s0";
    const interfaces = networkInterfaces()[name]

    if (interfaces) {
        let net = interfaces.filter(x => x.family === 'IPv4')[0].address

        if (net !== config.ip) {
            config.ip = net

            const data = `IP Updated: ${net} Date: ${moment().format('DD/MM/YYYY - HH:mm')}\n`

            fs.writeFileSync('./config.json', JSON.stringify(config, null, 4))
            fs.appendFileSync('./logs/config-ip.log', data)

            console.log(blue(data))
        }
    } else {
        console.warn(red("No internet connection to get IP!"))
    }
}

// startup
(() => {
    configIp()
})()