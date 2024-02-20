import api from "../../../services/api";

export const loginfunc = async (email: string, password: string) => {
    return await api.post('/login',
        {
            "username": email,
            "password": password
        }).then((res) => res.status);

};