import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }

  getToken(): string {
    return window.localStorage['auth_token'];
  }

  saveToken(token: string) {
    window.localStorage['auth_token'] = token;
  }

  getUserId(): string {
    return window.localStorage['UserId'];
  }

  saveUserId(userId: string) {
    window.localStorage['UserId'] = userId;
  }

  destroyToken() {
    window.localStorage.removeItem('auth_token');
    window.localStorage.removeItem('currentUser');
  }
}
