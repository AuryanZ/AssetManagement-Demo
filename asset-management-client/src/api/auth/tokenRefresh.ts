import api from "../../../services/api";

export const tokenRefresh = async () => {
    const token = localStorage.getItem('Account') || "{}";
    const tokenData = JSON.parse(token);
    const tokenExpirTime = tokenData.tokenExpirTime;
    const currentTime = Date.now() / 100000;
    const tokenTimeCount = await currentTime - tokenExpirTime / 100000;
    console.log("tokenTimeCount: ", tokenTimeCount);
    // console.log("differents: ", currentTime - tokenExpirTime / 100000)
    if (tokenTimeCount >= 30) {
        localStorage.clear();
        return null;
    }

    if (tokenTimeCount >= 0.01) {
        // console.log("tokenData: ",tokenData);
        try {
            var tokenResponse = await api.post('/account/refresh-token', tokenData).then((res) => res.data);
            console.log("tokenResponse: ", tokenResponse);
            tokenResponse.userRole = tokenData.userRole;
            tokenResponse.userName = tokenData.userName;
            tokenResponse.tokenExpirTime = Date.now();
            delete tokenResponse.message;
            delete tokenResponse.success;
            await localStorage.removeItem('Account');
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