import axios from "axios";
import { getToken } from "./auth";

const api = axios.create({
  baseURL: "https://agenda-medica-api.herokuapp.com/api",
});

api.interceptors.request.use((config) => {
  async function intercept(config) {
    const token = getToken();

    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
  }

  return intercept(config);
});

export default api;
