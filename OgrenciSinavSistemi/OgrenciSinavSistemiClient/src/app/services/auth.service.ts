import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user:any;
  token: string = "";

  constructor(
    private router: Router
  ) { }

  isAuthenticated(){
    const responseString = localStorage.getItem("response");
    if(responseString === null){
      this.router.navigateByUrl("/login")
      return false;
    }

    const response:any = JSON.parse(responseString);
    this.token = response.data;
    const decode = jwtDecode(response.data);
    this.user = decode;

    return true;
  }
}
