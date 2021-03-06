import { ProductService } from 'src/app/services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css'],
})
export class ProductEditComponent implements OnInit {
  currentProduct = {
    id: "",
    name: '',
    description: '',
    price: '',
    quantity: '',
    aquisitionDate: ''
  }

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getProduct(this.route.snapshot.paramMap.get('id'));
  }

  getProduct(id: any): void {
    this.productService.read(id).subscribe(
      (product) => {
        this.currentProduct = product;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  updateProduct(id: any): void {
    this.productService.update(id, this.currentProduct).subscribe(
      (response) => {
        this.router.navigate(['products']);
        console.log(response);
      },
      (error) => {
        console.log(error);
      });
  }
}
