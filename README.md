# Runtastic2Strava

https://yizeng.me/2017/01/11/get-a-strava-api-access-token-with-write-permission/

On October 15, 2018 Strava enhanched the authorization process introducing new list of scopes.

Are you using the access token you find on https://www.strava.com/settings/api?

This token has scope:read that maybe is not enough to do what you want (i.e. are your activities public or private?).

If you need a new token with different scopes you have to follow these steps.

STEP 1: redirect the user to Strava's authorization page:

https://www.strava.com/oauth/authorize?
    client_id=YOUR_CLIENT_ID&
    redirect_uri=YOUR_CALLBACK_DOMAIN&
    response_type=code&
    scope=YOUR_SCOPE
STEP 2: read code parameter from response:

http://YOUR_CALLBACK_DOMAIN/?
    state=&
    code=AUTHORIZATION_CODE_FROM_STRAVA&
    scope=YOUR_SCOPE
STEP 3: ask for a new access token using a POST containing the authorization code; you'll find the new access_token in the JSON response.

https://www.strava.com/oauth/token?
    client_id=YOUR_CLIENT_ID&
    client_secret=YOUR_CLIENT_SECRET&
    code=AUTHORIZATION_CODE_FROM_STRAVA&
    grant_type=authorization_code
You can find client ID, client secret and callback domain in your application page.

You can find the list of new scopes in this documentation.

If you are the only person that use your application you can manually do the first 2 steps using a browser and http://localhost as callback domain.