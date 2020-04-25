import axios from "@/services/ajax";

export default class UserService {
    public RequestVerification(user: any): Promise<never> {
        return axios.post("http://localhost:21021/api/Users/request-verification", user);
    }

    public CreateNewUser(user: any): Promise<any> {
        return axios.post("http://localhost:21021/api/Users/new", user).then(res => {
            return res.data.result;
        });
    }

    public Login(userName: string, password: string): any {
        const loginModel = {
            userNameOrEmailAddress: userName,
            password: password
        };

        console.log("Ayoka sucks", loginModel);
        return axios.post("http://localhost:21021/api/Auth", loginModel).then(response => {
            return response.data.result;
        });
    }

    public GetUser(id: number): any {
        return axios.get(`http://localhost:21021/api/Users/${id}`).then(res => {
            return res.data.result;
        });
    }

    public async GetUserConfig() {
        const response = await axios.get("http://localhost:21021/api/Users/config");
        return response.data.result;
    }
}