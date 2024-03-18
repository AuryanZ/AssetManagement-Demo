import api from "../../../services/api";

const getAllAssets = async () => {
    const response = api.get('/assets');

    return response;
}

const getAssetsByCondition = async (page: number, limit: number) => {
    const response = api.get('/assets/status=&location=&name=/' + page + '/' + limit);
    return response;
}

export { getAllAssets, getAssetsByCondition };

