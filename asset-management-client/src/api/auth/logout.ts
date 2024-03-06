import api from "../../../services/api";
import { removeToken } from "../../../services/token/token";

export const logoutfunc = async () => {
    const response = await api.get('account/logout');
    console.log(response);

    if (response.status === 200) {
        await removeToken();
        return response;
    } else {
        return response;
    }
};