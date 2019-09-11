import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';

import { ProductToCreate, ProductSubCategory, Supplier } from '../../../_models/product.model';

@Component({
  selector: 'create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  productToCreate: ProductToCreate;
  subcategories: ProductSubCategory[];
  suppliers: Supplier[];
  productForm: FormGroup;
  loading = false;
  submitted = false;

  @ViewChild('fileInput') fileInput: ElementRef;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private productService: ProductService
  ) {
    this.createForm();
  }

  ngOnInit() {
    //this.subcategories = this.productService.GetSubCategories();
    this.productService.GetSubCategories()
      .subscribe(categ => {
        this.subcategories = categ;

        console.log(this.subcategories);
      });

    this.productService.GetSuppliers()
      .subscribe(supp => {
        this.suppliers = supp;

        console.log(this.suppliers);
      });
  }

  get f() { return this.productForm.controls; }

  createForm() {
    this.productForm = this.formBuilder.group({
      title: ['', Validators.required],
      catdescription: ['', Validators.required],
      barcode: ['', Validators.required],
      price: ['', Validators.required],
      features: ['', Validators.required],
      usage: ['', Validators.required],
      cmbSubcategory: '',
      cmbSupplier: '',
      avatar: null
    });
  }

  onFileChange(event) {
    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.productForm.get('avatar').setValue({
          filename: file.name,
          filetype: file.type,
          value: reader.result.split(',')[1]
        })
      };
    }
  }

  clearFile() {
    this.productForm.get('avatar').setValue(null);
    this.fileInput.nativeElement.value = '';
  }

  onSubmit() {
    const formModel = this.productForm.value;

    this.productToCreate = {
      Title: formModel.title,
      Description: formModel.catdescription,
      ImageData: formModel.avatar.value,
      ImageType: formModel.avatar.filetype,
      Barcode: formModel.barcode,
      Price: formModel.price,
      ProductSubCategoryId: formModel.cmbSubcategory,
      SupplierId: formModel.cmbSupplier
    }

    this.loading = true;


    this.productService.CreateProduct(this.productToCreate)
      .subscribe(res => {
        console.log(res);
        //this.router.navigate(['category/manage']);
      },
        error => {
          console.log(error);
        });

    this.loading = false;
    this.productForm.reset();
    this.clearFile();
  }
}
