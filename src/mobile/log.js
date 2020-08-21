import chalk from 'chalk'

const ch = new chalk.Instance({ level: 3 })

export const error = (message, informal) => {
    console.log(informal ? ch.red(message) : ch.bgRed(message))
}

export const apiRequest = (message) => {
    console.log(ch.bgBlue('API_REQUEST', ch.inverse(message)))
}

export const temp = (message) => {
    console.log(ch.bgMagenta(message))
}

export const variable = (variable) => {
    let name = Object.keys(variable)[0]

    if (!name) console.log(ch.bgRed('Variable is not passed with brackets or with spread (...)!'), ch.red('Example: variable({ value }) or variable(...value)'))
    
    console.log(ch.bgCyan('VARIABLE'), ch.cyan(`${name}:`), ch.cyan(variable[name]))
}

export const info = (message) => {
    console.log(ch.blue(message))
}

export default {
    error,
    apiRequest,
    variable,
    temp,
}