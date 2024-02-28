import api from "../../../services/api";

export const logoutfunc = async (token: JSON) => {

    // console.log(loginJson)
    return api.post('account/logout', token).then((res) => res.data);
};