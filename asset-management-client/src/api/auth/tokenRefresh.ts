import api from "../../../services/api";

export const tokenRefresh = async () => {
    const token = await localStorage.getItem('Account');
    if (token == null) {
        return null;
    }
    const tokenData = JSON.parse(token);

    console.log("tokenData: ", tokenData);

    // try {
    var Response = await api.post('/account/refresh-token', tokenData).then((res) => res);
    console.log(Response.status);
    if (Response.status === 204) {
        return tokenData;
    }
    if (Response.status === 200) {

        var tokenResponse = Response.data;
        tokenResponse.userRole = tokenData.userRole;
        tokenResponse.userName = tokenData.userName;
        tokenResponse.tokenExpirTime = Date.now();
        delete tokenResponse.message;
        delete tokenResponse.success;
        await localStorage.removeItem('Account');
        await localStorage.setItem('Account', JSON.stringify(tokenResponse));
        return tokenResponse;
    }else{
        return null;
    }
    // } catch (error: any) {
    //     console.log(error);
    //     if (error.response && error.response.status === 204) {
    //         return tokenData;
    //     }
    //     return null;
    // }
};