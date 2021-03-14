var axios = require('axios');
var qs = require('qs');
var data = qs.stringify({
 'grant_type': 'client_credentials' 
});
var config = {
  method: 'post',
  url: 'https://dev.ipay.ge/opay/api/v1/oauth2/token/',
  headers: { 
    'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8', 
    'Authorization': 'Basic MTAwNjo1ODFiYTVlZWFkZDY1N2M4Y2NkZGM3NGM4MzliZDNhZA=='
  },
  data : data
};

console.log(data)

axios(config)
.then(function (response) {
  console.log(JSON.stringify(response.data));
})
.catch(function (error) {
  console.log(error);
});