import { ProductService } from './../../services/product.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  product = {
    name: "",
    description: "",
    price: "",
    quantity: "",
    aquisitionDate: ""
  }
  submitted = false;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  createdProduct(): void {
    const data = {
      name: this.product.name,
      description: this.product.description,
      price: this.product.price,
      quantity: this.product.quantity,
      aquisitionDate: this.product.aquisitionDate
    };
    this.productService.create(data).subscribe(
      response => {
        this.submitted = true;
      },
      error => {
        console.log(error);
      });
  }

  newProduct(): void {
    this.submitted = false,
    this.product = {
      name: '',
      description: '',
      price: '',
      quantity: '',
      aquisitionDate: ''
    }
  }
}
