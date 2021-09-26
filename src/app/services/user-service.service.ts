import {Injectable} from '@angular/core';
import { User } from '../model/user';


@Injectable({

  providedIn:'root'
})
export class UserServiceService{
  constructor(){}
  addUser(user : User){
    let users = [];
  if(localStorage.getItem('Users')){
  users =   JSON.parse(localStorage.getItem('Users'));
  users = [user, ...users];
  //already exist user and save multiple user in storage

  }

  else {
    users = [user];
    //if noo multiple user so assign new user array
  }
  localStorage.setItem('Users', JSON.stringify(users));
  }

}
