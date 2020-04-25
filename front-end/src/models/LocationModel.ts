export default class LocationModel {
    Name: string;
    PrimaryAddress: string;
    SecondaryAddress: string;
    City: string;
    State: string;
    ZipCode: number;

    constructor(name: string, primaryAddress: string, secondaryAddress: string, city: string, state: string, zipCode: number){
        this.Name = name;
        this.PrimaryAddress = primaryAddress;
        this.SecondaryAddress = secondaryAddress;
        this.City = city;
        this.State = state;
        this.ZipCode = zipCode;
    }
}