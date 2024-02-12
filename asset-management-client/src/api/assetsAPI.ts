import api from "../../services/api";

export const getAssets = async () => {
    try {
        const response = await api.get('/api/assets');
        return response.data;
    }
    catch (error) {
        console.error(error);
    }
}