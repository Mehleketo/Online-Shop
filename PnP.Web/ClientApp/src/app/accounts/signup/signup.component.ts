import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountsService } from '../../_services/accounts.service';

import {
  ApplicationUser, SignInModel, SignInViewModel,
  UserToCreate, SignUpViewModel, IdentificationType
} from '../../_models/user.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  user: UserToCreate;
  idTypes: IdentificationType[];
  userViewModel: SignUpViewModel;
  error: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private accountsService: AccountsService
  ) { }

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      identitype: ['', Validators.required],
      idnumber: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.accountsService.GetIdTypes()
      .subscribe(categ => {
        this.idTypes = categ;

        console.log(this.idTypes);
      });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.signupForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.signupForm.invalid) {
      return;
    }

    this.loading = true;

    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }

    this.user = {
      FirstName: this.f.firstname.value,
      LastName: this.f.lastname.value,
      IdNumber: this.f.idnumber.value,
      Email: this.f.email.value,
      Password: this.f.password.value,
      ConfirmPassword: this.f.password.value,
      IsSubscribed: false,
      IdentificationTypeId: this.f.identitype.value
    };

    this.loading = true;

    this.accountsService.register(this.user)
      .pipe(first())
      .subscribe(
        data => {
          console.log(data);
          this.router.navigate(['signin']);
        },
        error => {
          console.log(error);
          this.error = error;
          this.loading = false;
        });
  }
}
