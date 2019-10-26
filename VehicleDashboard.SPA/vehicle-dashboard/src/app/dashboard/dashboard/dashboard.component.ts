import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/vehicle/vehicle.service';
import { interval, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { VehicleModel } from 'src/app/vehicle/models/vehicle.model';
import { CustomerModel } from 'src/app/customer/models/customer.model';
import { CustomerService } from 'src/app/customer/customer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

  isConnected?: boolean;
  customerId?: number;
  vehicles: VehicleModel[] = [];
  customers: CustomerModel[] = [];
  subscription: Subscription;

  constructor(private vehicleService: VehicleService, private customerService: CustomerService) {
    this.getAllVehicles();
    this.getAllVehiclesPeriodically();
    this.getAllCustomers();
  }


  getAllVehiclesPeriodically() {
    const source = interval(5000);

    this.subscription = source.subscribe(val => this.vehicleService.getVehicles(this.isConnected, this.customerId)
      .subscribe(data => {
        this.vehicles = data;
      }));
  }

  getAllCustomers() {
    this.customerService.getAll().subscribe(data => {
      this.customers = data;
    });
  }

  getAllVehicles() {
    this.vehicleService.getVehicles(this.isConnected, this.customerId)
      .subscribe(data => {
        this.vehicles = data;
      });
  }
}
