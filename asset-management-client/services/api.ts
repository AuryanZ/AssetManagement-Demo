"use client"
import axios from 'axios';
import { setToken, getToken, removeToken, setRefreshToken } from './token/token';
import { get } from 'http';
import { tokenRefresh } from '@/api/auth/tokenRefresh';

const API_URL = process.env.NEXT_PUBLIC_API_URL;

const api = axios.create({
    baseURL: API_URL,
    headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${getToken()}`,
    },
    validateStatus: function (status) {
        return (status >= 200 && status < 300) || status === 401; // default is 'status >= 200 && status < 300'
    },
});

api.interceptors.response.use(async (res) => {
    if (res.headers.authorization) {
        const token = res.headers.authorization.replace('Bearer ', '');
        setToken(token);
        api.defaults.headers.Authorization = `Bearer ${token}`;
    }
    if (res.headers.refreshtoken) {
        const refreshToken = res.headers.refreshtoken.replace('Bearer ', '');
        setRefreshToken(refreshToken);
    }
    if (res.status === 401
        // && !isRefreshRequest(res.config)
    ) {
        // console.log('refresh token', isRefreshRequest(res.config));
        const isrefreshed = await tokenRefresh();
        if (isrefreshed) {
            if (res.config.headers) {
                res.config.headers.Authorization = `Bearer ${getToken()}`;
            }
            const response = await api.request(res.config);
            return response;
        }
    }
    return res.data;
});

export default api;
