export class VehicleModel {
    constructor(public id: number,public vin: string, public regNr: string, public isConnected: boolean) {
        this.id = id;
        this.vin = vin;
        this.regNr = regNr;
        this.isConnected = isConnected;
    }
}