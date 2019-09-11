import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service'

import { ProductCategory, ProductSubCategory, ProductSubCategoryToCreate } from '../../../_models/product.model'

@Component({
  selector: 'create-subcategory',
  templateUrl: './create-subcategory.component.html',
  styleUrls: ['./create-subcategory.component.css']
})
export class CreateSubcategoryComponent implements OnInit {

  subcategoryToCreate: ProductSubCategoryToCreate;
  categories: ProductCategory[];
  subcategoryForm: FormGroup;
  loading = false;
  submitted = false;

  @ViewChild('fileInput') fileInput: ElementRef;

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService
  ) {
    this.createForm();
  }

  ngOnInit() {
    //this.categories = this.productService.GetCategories();
    this.productService.GetCategories()
      .subscribe(categ => {
        this.categories = categ;

        console.log(this.categories);
      });
  }

  createForm() {
    this.subcategoryForm = this.formBuilder.group({
      title: ['', Validators.required],
      catdescription: ['', Validators.required],
      cmbCategory: '',
      avatar: null
    });
  }

  get f() { return this.subcategoryForm.controls; }

  onFileChange(event) {
    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.subcategoryForm.get('avatar').setValue({
          filename: file.name,
          filetype: file.type,
          value: reader.result.split(',')[1]
        })
      };
    }
  }

  clearFile() {
    this.subcategoryForm.get('avatar').setValue(null);
    this.fileInput.nativeElement.value = '';
  }

  onSubmit() {
    const formModel = this.subcategoryForm.value;

    this.subcategoryToCreate = {
      Title: formModel.title,
      Description: formModel.catdescription,
      ImageData: formModel.avatar.value,
      ImageType: formModel.avatar.filetype,
      CategoryId: formModel.cmbCategory
    }

    this.loading = true;

    this.productService.CreateSubCategory(this.subcategoryToCreate)
      .subscribe(res => {
        console.log(res);
        //this.router.navigate(['categories/manage']);
      },
        error => {
          console.log(error);
        });

    this.loading = false;
    this.subcategoryForm.reset();
    this.clearFile();
  }
}
