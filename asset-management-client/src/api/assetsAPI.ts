import api from "../../services/api";

let promise: Promise<any> | null;

export const getAssets = async () => {
    const response = api.get('/assets');

    return response;
}