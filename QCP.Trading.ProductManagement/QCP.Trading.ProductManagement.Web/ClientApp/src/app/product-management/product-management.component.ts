import { Component, OnInit } from '@angular/core';
import { ProductService } from './../services/product.service'
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-product-management',
  templateUrl: './product-management.component.html',
  styleUrls: ['./product-management.component.css'],
  providers: [ProductService, NgxSpinnerService]
})
export class ProductManagementComponent implements OnInit {

  productList = [];
  products = [];
  countries = [];
  country: string;
  barchartData: any;
  barchartOptions: any;

  constructor(private productService: ProductService, private loader: NgxSpinnerService) { }

  ngOnInit() {
    this.getTopSellingProducts();
  }

  getTopSellingProducts() {
    this.loader.show();
    this.productService.getTopSellingProducts().subscribe(result => {
      this.productList = result;
      this.products = result;
      this.countries = result.map(item => item.Country).filter((value, index, self) => self.indexOf(value) === index);
      this.applyChartOptions();
      this.loader.hide();
    });
  }

  onCountryChange(data) {
    if (this.country == "" || this.country == undefined)
      this.products = this.productList;
    else {
      this.products = this.productList.filter(x => x.Country == this.country);
    }
  }

  applyChartOptions() {
    let productNames = this.products.map(item => item.ProductName).filter((value, index, self) => self.indexOf(value) === index);
    let barcharDataSets = [];
    this.countries.forEach(x => {
      let data = [];
      productNames.forEach(p => {
        let productData = this.products.filter(f => f.ProductName == p && f.Country == x);
        if (productData.length > 0)
          data.push(productData[0].Orders);
      })
      let color = Math.floor(Math.random() * 16777215).toString(16);
      barcharDataSets.push({
        type: 'bar',
        label: x,
        backgroundColor: '#' + color,
        data: data
      })
    })

    this.barchartData = {
      labels: productNames,
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
