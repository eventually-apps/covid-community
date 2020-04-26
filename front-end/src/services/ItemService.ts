import axios from "axios";

export default class ItemService {

    public GetItemsByLocation(locationId: number): any {
        return axios.get(`http://localhost:21021/api/Item/getItemsByLocation?locationId=${locationId}`).then(response => {
            return response;
        });
    }
}