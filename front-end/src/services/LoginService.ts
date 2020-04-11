import axios from "axios";

export default class LoginService {

    public CreateNewUser(user: any): Promise<any> {
        return axios.post("http://localhost:21021/api/Users/new", user).then(res => {
            return res.data.result.user;
        });
    }

    public ValidateNewUser(verificationRequest: any): Promise<any> {
        return axios.post("http://localhost:21021/api/Users/verify", verificationRequest).then(res => {
            return res.data.result.user;
        });
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