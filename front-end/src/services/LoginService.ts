import axios from "@/services/ajax";

export default class LoginService {

    public CreateNewUser(user: any): Promise<any> {
        return axios.post("http://localhost:21021/api/Users/new", user).then(res => {
            return res.data.result.user;
        });
    }

    public async ValidateNewUser(verificationRequest: any): Promise<any> {
        const res = await axios.post("http://localhost:21021/api/Users/verify", verificationRequest);
        return res.data.result;
    }

    public Login(userName: string, password: string): any {
        const loginModel = {
            userNameOrEmailAddress: userName,
            password: password
        };

        return axios.post("http://localhost:21021/api/Auth", loginModel).then(response => {
            return response.data.result;
        });
    }

    public async GetUserConfig() {
        const response = await axios.get("http://localhost:21021/api/Users/config");
        return response.data.result;
    }
}