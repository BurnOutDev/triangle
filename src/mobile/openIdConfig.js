const openIdConfig = {
    issuer: 'http://192.168.100.7:5000/',
    clientId: 'nativeclient',
    redirectUrl: 'com.reserveproject:/oauthredirect',
    scopes: ['openid', 'profile', 'reservationapi']
}

export default openIdConfig