import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/core/services/product.service';
import { productCreatorModel } from 'src/app/core/shared/models';

@Component({
  selector: 'app-product-creator',
  templateUrl: './product-creator.component.html',
  styleUrls: ['./product-creator.component.css']
})
export class ProductCreatorComponent implements OnInit {
  productForm: any;

  constructor(private formBuilder: FormBuilder, private productService:ProductService,
    private router:Router) {}

  ngOnInit(): void {
    this.initializeForm();
  }
  product: productCreatorModel = new productCreatorModel();
  
  initializeForm(): void {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      category: ['', Validators.required],
      color: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) 
      this.productService.AddProduct(this.product).subscribe(res => {
        this.router.navigate(['']);

    }
    );

  }
}
