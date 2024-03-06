import api from "../../../services/api";

export const loginfunc = async (_formData: FormData) => {

    var loginData: { [key: string]: any } = {};
    _formData.forEach((value, key) => {
        loginData[key] = value;
    });

    var loginJson = JSON.stringify(loginData);
    // console.log(loginJson)
    try {
        const response = await api.post('account/login', loginJson);
        return response;
    } catch (err: any) {
        return err.response
    }
};