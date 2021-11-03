import { ProductService } from 'src/app/services/product.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: any;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.readProducts();
  }

  readProducts(): void {
    this.productService.rendAll().subscribe(
      products => {
        this.products = products;
      },
      error => {
        console.log(error);
      });
  }

  refresh(): void {
    this.readProducts();
  }

  deleteProduct(id: any){
    this.productService.delete(id).subscribe(response => {
      console.log(response);
    },
    error => {
      console.log(error);
    });
  }
}
