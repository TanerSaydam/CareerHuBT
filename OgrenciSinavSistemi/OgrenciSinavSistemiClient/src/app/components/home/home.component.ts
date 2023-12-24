import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  exams:any[] = [];

  constructor(
    public auth: AuthService,
    private http: HttpClient,
    private router: Router
  ){
    if(this.auth.user.IsTeacher === "True"){
      this.router.navigateByUrl("/admin")
    }    
    
    this.getExamList();
  }

  getExamList(){
    this.http.get("https://localhost:7000/api/StudentExamQuestions/GetExamsByStudentId", {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    })
    .subscribe({
      next: (res:any)=> {
        this.exams = res.data;
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }

  startExam(examId: string){
    this.http.get("https://localhost:7000/api/StudentExamQuestions/StartExamByExamId?examId=" + examId, {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    })
    .subscribe({
      next: (res:any)=> {
        this.router.navigateByUrl("/quiz/" + examId);
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }
}
