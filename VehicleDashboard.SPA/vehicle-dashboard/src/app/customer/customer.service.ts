import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { CustomerModel } from './models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get('http://localhost:8030/api/Customer/GetAll').pipe(map((data: CustomerModel[]) => data.map((item: CustomerModel) => new CustomerModel(
      item.id,
      item.fullName
    ))),
    );
  }
}
