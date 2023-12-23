import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  userName: string = "";

  constructor(
    private http: HttpClient,
    private router: Router
  ){}

  signIn(){
    const data= {userName: this.userName};

    this.http.post("https://localhost:7000/api/Auth/Login", data)
    .subscribe({
      next: (res:any)=> {
        localStorage.setItem("response",JSON.stringify(res));
        this.router.navigateByUrl("/");
      },
      error: (err:HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }
}
