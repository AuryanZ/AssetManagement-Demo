import api from "../../../services/api";
import { AxiosRequestConfig } from "axios";

let promise: Promise<any> | null;
// let __isRefreshToken = useRef(false)
interface CustomAxiosRequestConfig extends AxiosRequestConfig {
    __isRefreshToken?: boolean;
}

export const tokenRefresh = async () => {
    if (promise) {
        return promise;
    }

    // const refreshToken = localStorage.getItem('RefreshToken');
    // if (!refreshToken) {
    //     // No token in local storage. Handle this case as you see fit.
    //     return Promise.reject('No token in local storage').catch((error) => {
    //         throw error});
    // }

    promise = new Promise(async (resolve) => {
        const response = await api.get('account/refresh-token', {
            headers: {
                // Authorization: `Bearer ${getToken()}`,
                refreshToken: `Bearer ${localStorage.getItem('RefreshToken')}`
                // refreshToken: `Bearer ${refreshToken}`
            },
            __isRefreshToken: true
        } as CustomAxiosRequestConfig);
        console.log('refresh token response', response);
        resolve(response.status === 200)
    });

    // promise.catch((error) => {
    //     console.log('Error refreshing token', error);
    // });

    promise.finally(() => {
        promise = null;
    });
    return promise;
};

export function isRefreshRequest(config: any) {
    return !!config.__isRefreshToken;
}