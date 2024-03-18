import api from "../../../services/api";
import { removeToken } from "../../../services/token/token";

const getUserRole = async (username:string) => {
    return await api.get(`/account/user-role/${username}`).then((res) => res.data);
}

const logoutfunc = async () => {
    const response = await api.get('account/logout');

    if (response.status === 200) {
        await removeToken();
        return response;
    } else {
        return response;
    }
};

export { logoutfunc, getUserRole };