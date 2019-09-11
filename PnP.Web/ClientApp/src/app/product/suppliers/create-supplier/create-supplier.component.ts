import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';

import { ProductService } from '../../../_services/product.service';

import { SupplierToCreate } from '../../../_models/product.model';

@Component({
  selector: 'app-create-supplier',
  templateUrl: './create-supplier.component.html',
  styleUrls: ['./create-supplier.component.css']
})
export class CreateSupplierComponent implements OnInit {

  supplierToCreate: SupplierToCreate;
  supplierForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private productService: ProductService
  ) {
    this.createForm();
  }

  ngOnInit() {
  }

  get f() { return this.supplierForm.controls; }

  createForm() {
    this.supplierForm = this.formBuilder.group({
      companyName: ['', Validators.required],
      contactName: ['', Validators.required],
      contactTitle: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      province: ['', Validators.required],
      emailAddress: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      faxNumber: ['', Validators.required],
      homePage: ['', Validators.required]
    });
  }

  onSubmit() {
    const formModel = this.supplierForm.value;

    this.supplierToCreate = {
      CompanyName: formModel.companyName,
      ContactName: formModel.contactName,
      ContactTitle: formModel.contactTitle,
      Address: formModel.address,
      City: formModel.city,
      Province: formModel.province,
      EmailAddress: formModel.emailAddress,
      PhoneNumber: formModel.phoneNumber,
      FaxNumber: formModel.faxNumber,
      HomePage: formModel.homePage
    }

    this.loading = true;

    this.productService.CreateSupplier(this.supplierToCreate)
      .subscribe(res => {
        console.log(res);
      },
        error => {
          console.log(error);
        });

    this.loading = false;
    this.supplierForm.reset();
  }
}
