import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { BalloonService } from 'src/app/services/balloon.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, FormsModule],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
  

  constructor(
    private router: Router,
    public balloon: BalloonService,
    private http: HttpClient,
    public auth: AuthService
  ) { 

  }

  signOut(){
    localStorage.removeItem("token");
    this.auth.checkAuth();
    this.router.navigateByUrl("/login");
  }

  changeShowCommentDiv() {
    this.balloon.showCommentDiv = !this.balloon.showCommentDiv;
  }

  startConversation(form: NgForm) {
    if (form.valid) {
      this.http.post("https://livesupportwebapi.ecnorow.com/api/ChatRooms/CreateChatRoom", { nameLastname: form.controls["nameLastname"].value, subject: form.controls["chat"].value }).subscribe({
        next: (res: any) => {
          localStorage.setItem("whoAmI", form.controls["nameLastname"].value);
          this.router.navigateByUrl("/conversation/" + res.chatRoomId);
          this.balloon.showCommentDiv = false;
          this.balloon.shoCommentBalloon = false;
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      });
    }
  }


}
