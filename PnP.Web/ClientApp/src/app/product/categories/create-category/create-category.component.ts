import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { ProductService } from '../../../_services/product.service';

import { ProductCategoryToCreate } from '../../../_models/product.model';

@Component({
  selector: 'create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {

  categoryToCreate: ProductCategoryToCreate;
  categoryForm: FormGroup;
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

  ngOnInit() { }

  createForm() {
    this.categoryForm = this.formBuilder.group({
      title: ['', Validators.required],
      catdescription: ['', Validators.required],
      cmbCategory: '',
      avatar: null
    });
  }

  get f() { return this.categoryForm.controls; }

  onFileChange(event) {
    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.categoryForm.get('avatar').setValue({
          filename: file.name,
          filetype: file.type,
          value: reader.result.split(',')[1]
        })
      };
    }
  }

  clearFile() {
    this.categoryForm.get('avatar').setValue(null);
    this.fileInput.nativeElement.value = '';
  }

  onSubmit() {
    const formModel = this.categoryForm.value;

    this.categoryToCreate = {
      Title: formModel.title,
      Description: formModel.catdescription,
      ImageData: formModel.avatar.value,
      ImageType: formModel.avatar.filetype
    }

    this.loading = true;


    this.productService.CreateCategory(this.categoryToCreate)
      .subscribe(res => {
        console.log(res);
        //this.router.navigate(['category/manage']);
      },
        error => {
          console.log(error);
        });

    this.loading = false;
    this.categoryForm.reset();
    this.clearFile();
  }
}
