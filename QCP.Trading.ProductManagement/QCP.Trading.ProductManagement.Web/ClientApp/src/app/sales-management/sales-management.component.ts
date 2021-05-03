import { Component, OnInit } from '@angular/core';
import { OrderService } from './../services/order.service'
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-sales-management',
  templateUrl: './sales-management.component.html',
  styleUrls: ['./sales-management.component.css'],
  providers: [OrderService, NgxSpinnerService]
})
export class SalesManagementComponent implements OnInit {

  salesList = [];
  sales = [];
  countries = [];
  country: string;
  barchartData: any;
  barchartOptions: any;
  labels= ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

  constructor(private orderService: OrderService, private loader: NgxSpinnerService) { }

  ngOnInit() {
    this.getSalesByMonth();
  }

  getSalesByMonth() {
    this.loader.show();
    this.orderService.getSales().subscribe(result => {
      this.salesList = result;
      this.sales = result;
      this.countries = result.map(item => item.CustomerCountry).filter((value, index, self) => self.indexOf(value) === index);
      this.applyChartOptions();
      this.loader.hide();
    });
  }

  onCountryChange(data) {
    if (this.country == "" || this.country == undefined)
      this.sales = this.salesList;
    else {
      this.sales = this.salesList.filter(x => x.CustomerCountry == this.country);
    }
  }


  applyChartOptions() {
    let salesData = this.sales;
    //let months = this.sales.map(item => item.Month).filter((value, index, self) => self.indexOf(value) === index);
    let barcharDataSets = [];
    this.countries.forEach(x => {
      let data = [];
      this.labels.forEach(function (p) {
        //for (var f of this.sales) {
        //  if (f => f.Month == p && f.CustomerCountry == x) {
        //      data.push(f.OrderAmount);
        //  }
        //}
        let monthlyData = salesData.filter(f => f.Month == p && f.CustomerCountry == x);
        if (monthlyData.length > 0)
          data.push(monthlyData[0].OrderAmount);
      });
      let color = Math.floor(Math.random() * 16777215).toString(16);
      barcharDataSets.push({
        type: 'bar',
        label: x,
        backgroundColor: '#' + color,
        data: data
      })
    })

    this.barchartData = {
      labels: this.labels,
      datasets: barcharDataSets
    };

    this.barchartOptions = {
      tooltips: {
        mode: 'index',
        intersect: false
      },
      responsive: true,
      scales: {
        xAxes: [{
          stacked: true,
        }],
        yAxes: [{
          stacked: true
        }]
      }
    };
  }

}
