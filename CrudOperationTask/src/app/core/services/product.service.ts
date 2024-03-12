import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { productCreatorModel, productDetailsModel } from '../shared/models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient:HttpClient) { }

  Url = "http://localhost:9500/api/Products";


  GetAllProducts(){
    return this.httpClient.get<productDetailsModel[]>(this.Url)
  }
  GetProduct(id:number){
    return this.httpClient.get<productDetailsModel>(`${this.Url}/${id}`)
  }
  AddProduct(product:productCreatorModel){
    return this.httpClient.post(`${this.Url}/add`,product)
  }
  UpdateProduct(id:number, product:productCreatorModel){
    return this.httpClient.post(`${this.Url}/update/${id}`,product)
  }
  DeleteProduct(id:number){
    return this.httpClient.delete(`${this.Url}/delete/${id}`)
  }
}
