const openIdConfig = {
    issuer: 'https://idpserverirakli.azurewebsites.net/',
    clientId: 'nativeclient',
    redirectUrl: 'net.azurewebsites.idpserverirakli:/oauthredirect',
    scopes: ['openid', 'profile', 'reservationapi']
}

export default openIdConfig