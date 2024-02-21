import api from "../../../services/api";

export const loginfunc = async (_formData:FormData) => {

    var loginData : { [key: string]: any } = {};
    _formData.forEach((value, key)=> {
        loginData[key] = value;
    });
    
    var loginJson = JSON.stringify(loginData);
    return api.post('/login', loginJson).then((res) => res.status);
};