import api from "../../../services/api";

export const getUserInfo = async (username: string) => {
    return await api.get(`/login/username/${username}`).then((res) => res.data);
}