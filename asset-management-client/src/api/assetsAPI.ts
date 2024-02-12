import axios, { Axios, AxiosInstance } from "axios";

const axiosInstance : AxiosInstance = axios.create({
    baseURL: process.env.NEXT_PUBLIC_API_URL,
    headers: {
        "Content-type": "application/json"
    }
    });
