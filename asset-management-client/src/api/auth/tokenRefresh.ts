import { useRef } from "react";
import api from "../../../services/api";

let promise: Promise<any> | null;
// let __isRefreshToken = useRef(false)

export const tokenRefresh = async () => {
    if (promise) {
        return promise;
    }
    promise = new Promise(async (resolve) => {
        const response = await api.get('account/refresh-token', {
            headers: {
                // Authorization: `Bearer ${getToken()}`,
                refreshToken: `Bearer ${localStorage.getItem('RefreshToken')}`
            }
        });
        // __isRefreshToken.current = true;
        resolve(response.status === 200)
    });

    promise.finally(() => {
        promise = null;
    });

};

// export function isRefreshRequest(config: any) {
//     return !!config.__isRefreshToken;
// }