import api from "../../services/api";

export const getAssets = async () => {
    try {
        const response = api.get('/assets');

        return response;
    }
    catch (error) {
        console.error("Failed to fetch data", error);
    }
}