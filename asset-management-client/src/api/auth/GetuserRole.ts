import api from "../../../services/api";

export const getUserRole = async (username:string) => {
    return await api.get(`/account/user-role/${username}`).then((res) => res.data);
}