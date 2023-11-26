import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { jwtDecode } from 'jwt-decode';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  obj = {
    userName: "sevin",
    password: "1"
  }

  constructor(
    private router: Router,
    private http: HttpClient,
    private auth: AuthService
  ){}

  signIn(){
    this.http.post("https://livesupportwebapi.ecnorow.com/api/Auth/Login",this.obj)
    .subscribe({
      next: (res: any)=> {
        localStorage.setItem("token", res.token);
        const decode:any = jwtDecode(res.token);
        localStorage.setItem("whoAmI", decode["Name"])        
        localStorage.setItem("userId", decode["UserId"])        
        this.auth.checkAuth();
        this.router.navigateByUrl("/admin");
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);
      }
    })
      
  }
}
