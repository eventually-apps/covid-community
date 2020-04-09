import UserModel  from "../models/UserModel";
import axios from "axios";

export default class LoginService {

    public CreateNewUser(user: any): any {
        let response: any;

        axios.post("http://localhost:21021/api/Users/new", {
            body: user
        }).then(res => {
            response = res;
        }).catch(err => {
            console.log(err);
        });

        return response;
    }

    public ValidateNewUser(): any {
        return null;
    }

    public Login(user: UserModel): any {
        return null;
    }
}