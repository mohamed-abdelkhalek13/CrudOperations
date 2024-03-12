import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/core/services/product.service';
import { productCreatorModel } from 'src/app/core/shared/models';

@Component({
  selector: 'app-product-editor',
  templateUrl: './product-editor.component.html',
  styleUrls: ['./product-editor.component.css']
})
export class ProductEditorComponent implements OnInit {
  productForm: any;

  constructor(private formBuilder: FormBuilder, private productService:ProductService,
    private router:Router, private activatedRoute:ActivatedRoute) {}
    productId:number = 0;
  ngOnInit(): void {
    this.initializeForm();
    this.loadData()
  }
  product: productCreatorModel = new productCreatorModel();
  
  initializeForm(): void {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      category: ['', Validators.required],
      color: ['', Validators.required],
    });
  }
  loadData(){
    this.activatedRoute.params.subscribe(p => {
      this.productId = p['id'];
      this.productService.GetProduct(p['id']).subscribe(res =>{
        this.product = res;
      })
    })
  }

  onSubmit(): void {
    if (this.productForm.valid) 
      this.productService.UpdateProduct(this.productId,this.product).subscribe(res => {
        this.router.navigate(['']);
    });
  }
}
