const openIdConfig = {
    issuer: 'https://idpserverirakli.azurewebsites.net/',
    clientId: 'nativeclient',
    redirectUrl: 'com.reserveapp:/oauthredirect',
    scopes: ['openid', 'profile', 'reservationapi']
}

export default openIdConfig