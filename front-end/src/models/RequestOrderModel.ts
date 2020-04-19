import request from "../models/RequestModel";

export default class RequestOrderModel {
    OrderRequestedByUserId: number;
    OrderForLocationId: number;
    requests: request[];

    constructor(OrderRequestedByUserId: number, OrderForLocationId: number, requests: request[]) {
        this.OrderRequestedByUserId = OrderRequestedByUserId;
        this.OrderForLocationId = OrderForLocationId;
        this.requests = requests;
    }
}