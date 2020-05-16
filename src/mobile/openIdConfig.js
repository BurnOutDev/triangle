const openIdConfig = {
    issuer: 'https://reserveidentityserver.azurewebsites.net/',
    clientId: 'nativeclient',
    redirectUrl: 'net.azurewebsites.reserveidentityserver:/oauthredirect',
    scopes: ['openid', 'profile', 'reservationapi']
}

export default openIdConfig