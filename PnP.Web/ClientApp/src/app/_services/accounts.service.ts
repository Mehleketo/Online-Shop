import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject, ReplaySubject } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
//import { JwtHelperService } from '@auth0/angular-jwt';

import { ApiService } from './api.service';
import { JwtService } from './jwt.service';

import {
  SignInModel,
  SignInViewModel,
  UserToCreate,
  SignUpViewModel,
  IdentificationType
} from '../_models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  private currentUserSubject = new BehaviorSubject<SignInViewModel>({} as SignInViewModel);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(
    private apiService: ApiService,
    private http: HttpClient,
    private jwtService: JwtService,
    //public jwtHelper: JwtHelperService
  ) { }

  login(user: SignInModel): Observable<SignInViewModel> {
    return this.http.post<any>(`api/Accounts/Login`, user)
      .pipe(map(user => {
        this.setAuth(user);

        return user as SignInViewModel;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    this.purgeAuth();

    localStorage.clear();
  }

  loggedIn() {
    if (this.jwtService.getToken()) {
      return true;
    }
    else {
      return false;
    }

    //return true;
    //return this.jwtHelper.isTokenExpired('auth_token');
  }

  register(user: UserToCreate): Observable<SignUpViewModel> {
    return this.http.post<any>(`api/Accounts/Register`, user)
      .pipe(map(data => {
        return data as SignUpViewModel;
      }));
  }

  getCurrentUser(): SignInViewModel {
    return this.currentUserSubject.value;
  }

  update(user): Observable<SignUpViewModel> {
    return this.apiService.put('/user', { user })
      .pipe(map(data => {
        // Update the currentUser observable
        this.currentUserSubject.next(data.user);
        return data.user;
      }));
  }

  // Identification Type

  GetIdTypes(): Observable<IdentificationType[]> {
    return this.http.get('api/identificationtypes')
      .pipe(map(data => {
        return data as IdentificationType[];
      }));
  };


  // Helper Methods

  setAuth(user) {
    // Save JWT sent from server in localstorage
    this.jwtService.saveToken(user.token);

    this.jwtService.saveUserId(user.Id);

    // Set current user data into observable
    this.currentUserSubject.next(user);

    // Set isAuthenticated to true
    this.isAuthenticatedSubject.next(true);
  }

  purgeAuth() {
    // Remove JWT from localstorage
    this.jwtService.destroyToken();
    // Set current user to an empty object
    this.currentUserSubject.next({} as SignInViewModel);
    // Set auth status to false
    this.isAuthenticatedSubject.next(false);
  }
}
