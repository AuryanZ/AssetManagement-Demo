import api from "../../../services/api";

export const tokenRefresh = async (token: string) => {
    if (token === '') return null;
    const tokenData = JSON.parse(token);
    const tokenExpirTime = tokenData.tokenExpirTime;
    const currentTime = Date.now() / 100000;

    // console.log("differents: ", currentTime - tokenExpirTime / 100000)
    if (currentTime - tokenExpirTime / 100000 >= 30) {
        localStorage.clear();
        return null;
    }
    if (currentTime - tokenExpirTime / 100000 >= 0.1) {
        console.log("tokenData: ",tokenData);
        try {
            var tokenResponse = await api.post('/account/refresh-token', tokenData).then((res) => res.data);
            console.log(tokenResponse);
            tokenResponse.userRole = tokenData.userRole;
            tokenResponse.userName = tokenData.userName;
            tokenResponse.tokenExpirTime = Date.now();
            await localStorage.clear();
            await localStorage.setItem('Account', JSON.stringify(tokenResponse));
            return tokenResponse;
        } catch(error) {
            return error
        }
    }
    else {
        return token;
    }
};