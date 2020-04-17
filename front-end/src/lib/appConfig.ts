import UserConfig from "@/models/UserConfig"

let appConfig: UserConfig = {
    userConfig: {},
    sessionInfo: {}
};

export function getAppConfig(): UserConfig {
    return appConfig;
}

export function setAppConfig(config: UserConfig) {
    appConfig = config;
}

export function setToken(token: string) {
    localStorage.setItem('user-token', token);
}

export function clearToken() {
    localStorage.removeItem('user-token');
}

export function getToken(): string {
    const token = localStorage.getItem('user-token');
    if (!token) {
        return "";
    }

    return token;
}