import api from "../../../services/api";
import { AxiosRequestConfig } from "axios";

let promise: Promise<any> | null;
// let __isRefreshToken = useRef(false)

export const tokenRefresh = async () => {
    if (promise) {
        return promise;
    }
    interface CustomAxiosRequestConfig extends AxiosRequestConfig {
        __isRefreshToken?: boolean;
    }

    promise = new Promise(async (resolve) => {
        const response = await api.get('account/refresh-token', {
            headers: {
                // Authorization: `Bearer ${getToken()}`,
                refreshToken: `Bearer ${localStorage.getItem('RefreshToken')}`
            },
            __isRefreshToken: true
        } as CustomAxiosRequestConfig);
        resolve(response.status === 200)
    });

    promise.finally(() => {
        promise = null;
    });

};

export async function isRefreshRequest(config: any) {
    return !!config.__isRefreshToken;
}