import api from "../../../services/api";

export const logoutfunc = async () => {

    // console.log(loginJson)
    const token = await localStorage.getItem('Account');

    if (token == null) {
        return null;
    }
    const tokenData = JSON.parse(token);
    const response = await api.post('account/logout', tokenData).then((res) => res.data);

    if (response.success === true) {
        await localStorage.removeItem('Account');
        return response;
    } else {
        return response;
    }
};