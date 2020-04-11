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

    public Login(authRequest: any): Promise<any> {
        return axios.post("http://localhost:21021/api/Auth", authRequest).then(res => {
            return res.data.result.user;
        });
    }
}