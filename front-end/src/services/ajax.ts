import axios, { AxiosInstance } from "axios";
import { getToken } from "@/lib/appConfig";

const ajax: AxiosInstance = axios.create();
ajax.interceptors.request.use((config) => {
    const token = getToken();
    if (token !== "") {
        config.headers.common.Authorization = `Bearer ${token}`;
    }

    return config;
})

export default ajax;