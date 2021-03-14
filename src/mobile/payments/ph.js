const express = require('express')
const SDK = require('./CustomSDK/SDK')

const app = express()

const ipay = new SDK.Ipay({
    intent: "AUTHORIZE",
    username: "1006",
    password: "581ba5eeadd657c8ccddc74c839bd3ad",
    api: "dev.ipay.ge",//dev.ipay.ge developer mode, ipay.ge production mode
    redirect_url: "http://localhost:3000",
    shop_order_id: "Shop order id",
    card_transaction_id: "",
    locale: "ka",
    industry_type: "ECOMMERCE",
    currency_code: "GEL"
});

const pay = async (products) => {
    const order = await ipay.createOrder(products)
    console.log(order)
    return order
}

app.post('/pay', (req, res) => {
    console.log(res.json())
})

app.listen(3000)