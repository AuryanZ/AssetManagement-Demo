const setToken = (token: string) => {
    if (typeof window !== 'undefined') {
        localStorage.setItem('Account', token);
    }
}

const getToken = () => {
    if (typeof window !== 'undefined') {
        return localStorage.getItem('Account');
    }
}

const removeToken = () => {
    if (typeof window !== 'undefined') {
        localStorage.removeItem('Account');
        localStorage.removeItem('RefreshToken');
    }
}

const setRefreshToken = (token: string) => {
    if (token && typeof window !== 'undefined') {
        localStorage.setItem('RefreshToken', token);
    }
}

const decodeToken = () => {
    const token = localStorage.getItem('Account');
    if (!token) return null;
    const base64Url = token ? token.split('.')[1] : '';
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload);
}

export { setToken, getToken, removeToken, setRefreshToken, decodeToken };
// export { setRefreshToken } from './token'; // Remove this line

