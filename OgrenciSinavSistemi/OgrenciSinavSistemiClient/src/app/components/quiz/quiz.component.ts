import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-quiz',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './quiz.component.html',
  styleUrl: './quiz.component.css'
})
export class QuizComponent {
  examId: string = "";
  answer: string = "";
  questions: any[] = [];
  whichQuestion: number = 0;
  min: number = 29;
  sec: number = 59;

  constructor(
    private activated: ActivatedRoute,
    private http: HttpClient,
    private auth: AuthService,
    private router :Router
  ){
    this.activated.params.subscribe(res=> {
      this.examId = res["value"];

      this.http.get("https://localhost:7000/api/StudentExamQuestions/GetExamQuestionsByExamId?examId=" + this.examId, {
        headers: {
          "Authorization": "Bearer " + this.auth.token
        }
      }).subscribe({
        next: (res:any)=> {
          this.questions = res.data;
          setInterval(()=> {
            this.sec--;
            if(this.sec < 0){
              if(this.min > -1){
                this.sec = 59;
                this.min--
              }              
            }

            if(this.min <= 0 && this.sec <= 0){
              alert("Süreniz dolduğu için sınav sonlandırıldı!");
              this.router.navigateByUrl("/");
            }

          },1000);
        },
        error: (err: HttpErrorResponse)=> {
          console.log(err);          
        }
      })
    })
  }

  nextQuestion(id:number){
    const data = {examQuestionId: id, answer: this.answer};

    this.http.post("https://localhost:7000/api/StudentExamQuestions/AnswerTheQuestion", data,{
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    })
    .subscribe({
      next: (res:any)=> {
        this.whichQuestion++; 
        if(this.whichQuestion === this.questions.length){
          this.router.navigateByUrl("/");
        }
        this.answer = "";
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }
}
