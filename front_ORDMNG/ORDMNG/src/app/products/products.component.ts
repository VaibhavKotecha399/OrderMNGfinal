import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Products } from '../models/products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styles: [
  ]
})
export class ProductsComponent implements OnInit {

  constructor(public productservice:ProductsService) { 

  }
  productList: Products[];
  ngOnInit(): void {
    this.productservice.getProduct().subscribe(data=>{
      this.productList = data as Products[]
    });
  }

}
