import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuth: boolean  = false;
  constructor() { 
    this.checkAuth();
  }

  checkAuth(){
    if(localStorage.getItem("token")){
      this.isAuth = true;
    }else{
      this.isAuth = false;
    }
  }
}
