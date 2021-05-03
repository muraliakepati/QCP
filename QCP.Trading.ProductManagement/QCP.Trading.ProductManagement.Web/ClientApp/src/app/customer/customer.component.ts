import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerService } from './../services/customer.service'
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService, NgxSpinnerService]
})
export class CustomerComponent implements OnInit {
  customers = [];
  FirstName: string;
  LastName: string;
  City: string;
  Country: string;
  Phone: string;
  totalRecords: number;

  constructor(private customerService: CustomerService, private loader: NgxSpinnerService) { }

  ngOnInit() {
    this.getCustomers();
    this.setDefaults();
  }

  setDefaults() {
    this.FirstName="";
    this.LastName="";
    this.City="";
    this.Country="";
    this.Phone="";
  }

  getCustomers() {
    this.loader.show();
    this.customerService.getCustomers().subscribe(result => {
      this.customers = result;
      this.totalRecords = this.customers.length;
      this.loader.hide();
    });
  }

  saveCustomer() {
    this.loader.hide();
    let customer = {
      Id: 0,
      FirstName: this.FirstName,
      LastName: this.LastName,
      City: this.City,
      Country: this.Country,
      Phone: this.Phone
    }
    this.customerService.saveCustomer(customer).subscribe(result => {
      customer.Id = result;
      this.customers.push(customer);
      this.setDefaults();
      this.loader.hide();
    });
  }

  onRowEditInit(data: any) {
    console.log('Row edit initialized');
  }

  onRowEditSave(data: any) {
    this.loader.hide();
    let customer = {
      Id: 0,
      FirstName: this.FirstName,
      LastName: this.LastName,
      City: this.City,
      Country: this.Country,
      Phone: this.Phone
    }
    this.customerService.saveCustomer(customer).subscribe(result => {
      this.loader.hide();
    });
  }

  onRowEditCancel(data: any, index: number) {
    console.log('Row edit cancelled');
  }

}
