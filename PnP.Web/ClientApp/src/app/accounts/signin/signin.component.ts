import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { error } from '@angular/compiler/src/util';
import { first } from 'rxjs/operators';

import { AccountsService } from '../../_services/accounts.service';

import { ApplicationUser, SignInModel, SignInViewModel } from '../../_models/user.model';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  signinForm: FormGroup;
  user: SignInModel;
  loading = false;
  submitted = false;
  returnUrl: string;
  error: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private accountsService: AccountsService
  ) { }

  ngOnInit() {
    this.signinForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.signinForm.controls; }


  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.signinForm.invalid) {
      return;
    }

    this.user = {
      Username: this.f.email.value,
      Password: this.f.password.value
    }

    this.loading = true;

    this.accountsService.login(this.user)
      .pipe(first())
      .subscribe(
        data => {
          //console.log(data.token);
          this.router.navigate([this.returnUrl]);
        },
        error => {
          console.log(error);
          this.error = error;
          this.loading = false;
        });
  }
}
