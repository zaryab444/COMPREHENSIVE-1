import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { userForLogin, UserForRegister } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  authUser(user: userForLogin){
return this.http.post(this.baseUrl + '/account/login', user);
  }

  registerUser(user : UserForRegister){
    return this.http.post(this.baseUrl + '/account/register', user);
  }

}
