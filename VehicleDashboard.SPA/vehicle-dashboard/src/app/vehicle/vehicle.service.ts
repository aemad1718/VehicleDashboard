import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VehicleModel } from './models/vehicle.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getVehicles(isConnected?: boolean, customerId?: number): Observable<VehicleModel[]>{
    return this.http.get('http://localhost:8030/api/Vehicle/GetVehicles', {
      params: {
        isConnected: isConnected == null ? '' : String(isConnected),
        customerId: customerId == null ? '' : String(customerId),
      }
    }).pipe(map((data: VehicleModel[]) => data.map((item: VehicleModel) => new VehicleModel (
        item.id,
        item.vin,
        item.regNr,
        item.isConnected
      ))),
    );
  }
}
