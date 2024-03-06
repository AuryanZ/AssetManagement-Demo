import api from "../../services/api";

export const getAssets = async () => {
    try {
        const response = await api.get('/assets');
        return response.data;
    }
    catch (error) {
        console.error("Failed to fetch data", error);
    }
}