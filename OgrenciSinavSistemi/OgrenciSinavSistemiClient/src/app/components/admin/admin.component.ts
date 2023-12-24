import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  exams: any[] = [];
  students: any[] = [];

  setExamForStudents:{examId: string, studentIds: string[]} = {
    examId: "",
    studentIds: []
  }

  addExam: any = {
    title: "",
    questions: []
  };

  constructor(
    private auth: AuthService,
    private router: Router,
    private http: HttpClient
  ) {
    if (this.auth.user.IsTeacher === "False") {
      this.router.navigateByUrl("/")
    }

    this.getAllExams();
    this.getStudents();
  }

  getAllExams() {
    this.http.get("https://localhost:7000/api/Exams/GetAll")
      .subscribe({
        next: (res: any) => {
          this.exams = res.data;
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      })

  }

  getStudents(){
    this.http.get("https://localhost:7000/api/Students/GetAllStudent")
    .subscribe({
      next: (res:any)=> {
        this.students = res.data
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }

  addQuestion() {
    const data: { question: string, answerA: string, answerB: string, answerC: string, answerD: string, correctAnswer: string } = {
      question: "",
      answerA: "",
      answerB: "",
      answerC: "",
      answerD: "",
      correctAnswer: ""
    };

    this.addExam.questions.push(data)
  }

  createExam() {
    this.http.post("https://localhost:7000/api/Exams/Create",this.addExam).subscribe({
      next: (res:any)=> {
        const el = document.getElementById("addModalCloseBtn");
        el?.click();
        this.addExam = {
          title: "",
          questions: []
        }
        this.getAllExams();
      },
      error: (err:HttpErrorResponse)=> {
        console.log(err);        
      }
    })    
  }


  setExam(){
    this.http.post("https://localhost:7000/api/StudentExams/AddRange", this.setExamForStudents)
    .subscribe({
      next: (res:any)=> {
        const el = document.getElementById("addStudentExamsModalCloseBtn")
        el?.click();
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }

  addStudentExam(event:any, studentId: string){    
    if(event.target.checked){
      this.setExamForStudents.studentIds.push(studentId);
    }else{
      const index = this.setExamForStudents.studentIds.findIndex(p=> p == studentId);
      this.setExamForStudents.studentIds.splice(index, 1)
    }    
  }
}
