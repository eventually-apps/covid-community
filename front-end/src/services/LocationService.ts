import axios from "@/services/ajax";

export default class LocationService {

    public GetLocation(locationId: number): any {
        return axios.get(`http://localhost:21021/api/Location/getLocation?locationId=${locationId}`).then(response => {
            return response;
        });
    }
}