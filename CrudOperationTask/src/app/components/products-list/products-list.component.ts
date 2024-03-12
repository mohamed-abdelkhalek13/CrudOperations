import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/core/services/product.service';
import { productDetailsModel } from 'src/app/core/shared/models';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
 constructor(private productService: ProductService, private router:Router){}
 Url = "http://localhost:9500/api/Products";

  ngOnInit(): void {
    this.GetAllProducts();
  }


 productList:productDetailsModel[]=[];


 GetAllProducts(){
  this.productService.GetAllProducts().subscribe(
    res=> this.productList = res
  );
 }
 RemoveProduct(id:number){
  this.productService.DeleteProduct(id).subscribe(res => {
    location.reload();
  });
 }

 
}
