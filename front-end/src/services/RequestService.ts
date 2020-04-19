import axios from "@/services/ajax";

export default class RequestService {
    public GetRequestOrderByUser(userId: number): any {
        return axios.get("http://localhost:21021/api/RequestOrder/getRequestOrder/").then(res => {
            return res;
        });
    }
}