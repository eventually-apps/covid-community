import axios from "@/services/ajax";

export default class RequestService {
    public GetRequestOrderByUser(userId: number): any {
        return axios.get(`http://localhost:21021/api/RequestOrder/getRequestOrder?userId=${userId}`).then(response => {
            return response;
        });
    }

    public CreateRequest(requestOrderId: number, request: any): any {
        return axios.post(`http://localhost:21021/api/RequestOrder/createRequest?requestOrderId=${requestOrderId}`, request).then(response => {
            return response.data.result;
        });
    }

    public CancelRequest(requestOrderId: number, requestId: number): any {
        const params = {
            RequestOrderId: requestOrderId,
            RequestId: requestId
        };

        return axios.post("http://localhost:21021/api/RequestOrder/cancelRequest", params).then(response => {
            return response.data.result;
        });
    }
}