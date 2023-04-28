import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Products } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
   producturl:string="http://localhost:49680/api/Products";
  constructor(readonly objHttp:HttpClient) { }

  getProduct(){
    return this.objHttp.get(this.producturl)
  }
}
