import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Products } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  readonly producturl:string="http://localhost:49680/api/Products";
  constructor(public objHttp:HttpClient) { }

  productList: Products[];
  productData: Products=new Products();
  getProduct(){
    return this.objHttp.get(this.producturl)
  }

  postProduct(){
    return this.objHttp.post(this.producturl, this.productData);
  }

  putProducts(){
    return this.objHttp.put(this.producturl + "/"+ this.productData.Pid,this.productData);
  }

  deleteProducts(Pid){
    return this.objHttp.delete(this.producturl+"/"+Pid);
  }
}
