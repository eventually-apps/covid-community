export class RequestOrderModel {

    constructor(public RequestOrderId: number, public OrderRequestedByUserId: number,
        public OrderForLocationId: number, public requests: any[]) {
    }
}