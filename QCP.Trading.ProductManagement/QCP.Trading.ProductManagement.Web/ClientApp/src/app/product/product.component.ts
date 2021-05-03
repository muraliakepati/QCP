import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from './../services/product.service'
import { SupplierService } from './../services/supplier.service'
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService, SupplierService, NgxSpinnerService]
})
export class ProductComponent implements OnInit {

  products=[];
  suppliers = [];
  ProductName: string;
  SupplierId: number;
  UnitPrice: number;
  Package: string;
  IsDiscontinued: boolean;
  totalRecords: number;

  constructor(private productService: ProductService, private supplierService: SupplierService, private loader: NgxSpinnerService) { }

  ngOnInit() {
    this.getProducts();
    this.getSuppliers();
    this.setDefaultValues();
  }

  setDefaultValues() {
    this.ProductName = "";
    this.SupplierId = 0;
    this.UnitPrice=0;
    this.Package="";
    this.IsDiscontinued=false;
  }

  getProducts() {
    this.loader.show();
    this.productService.getProducts().subscribe(result => {
      this.products = result;
      this.totalRecords = this.products.length;
      this.loader.hide();
    });
  }

  getSuppliers() {
    this.loader.show();
    this.supplierService.getSuppliers().subscribe(result => {
      this.suppliers = result;
      this.loader.hide();
    });
  }

  saveProduct() {
    this.loader.hide();
    let supplier = this.suppliers.filter(x => x.Id == this.SupplierId);
    let product = {
      Id:0,
      ProductName: this.ProductName,
      SupplierId: this.SupplierId,
      UnitPrice: this.UnitPrice,
      Package: this.Package,
      IsDiscontinued:this.IsDiscontinued
    }
    this.productService.saveProduct(product).subscribe(result => {
      product.Id = result;
      product["Supplier"] = supplier[0];
      this.products.push(product);
      this.setDefaultValues();
      this.loader.hide();
    });
  }

  onRowEditInit(data: any) {
    console.log('Row edit initialized');
  }

  onRowEditSave(data: any) {
    this.loader.hide();
    let product = {
      Id: data.Id,
      ProductName: data.ProductName,
      SupplierId: data.SupplierId,
      UnitPrice: data.UnitPrice,
      Package: data.Package,
      IsDiscontinued: data.IsDiscontinued
    }
    this.productService.saveProduct(product).subscribe(result => {
      this.loader.hide();
    });
  }

  onRowEditCancel(data: any, index: number) {
    console.log('Row edit cancelled');
  }

}
