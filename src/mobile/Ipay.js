const SDK = require('./payments/CustomSDK/SDK')

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

const items = [
    { product_id: "123456789", quantity: 1, amount: 1.00, description: "product description text 1" },
    { product_id: "987654321", quantity: 3, amount: 5.00, description: "product description text 2" }
];