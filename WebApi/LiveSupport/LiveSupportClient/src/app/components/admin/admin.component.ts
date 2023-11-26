import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  chatRooms: ChatRoom[] = [];
  
  constructor(
    private http: HttpClient,
    private router: Router,
    private signalR: SignalRService
  ){
    this.getAll();
    this.signalR.startConnection().then(()=> {
      this.signalR.getCreatedRoomData((res:any)=> {      
        this.chatRooms.unshift(res);
      })
    });   
  }

  getAll(){
    this.http.post("https://livesupportwebapi.ecnorow.com/api/Admin/GetAllChatRoom", {})
    .subscribe({
      next: (res: any)=> {
        this.chatRooms = res;
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }

  connectConversation(chatRoomId: string){
    const userId = localStorage.getItem("userId");
    this.http.post("https://livesupportwebapi.ecnorow.com/api/Admin/ConnectChatRoom", {chatRoomId: chatRoomId, userId: userId}).subscribe({
      next: (res: any)=> {
        this.router.navigateByUrl("/conversation/" + chatRoomId)
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }
}

export interface ChatRoom {
  number: number
  clientNameLastname: ClientNameLastname
  subject: Subject
  createdDate: string
  isClosed: boolean
  whoIsTheLastAnswer: WhoIsTheLastAnswer
  lastAnswerDate: string
  userId: any
  user: any
  chatRoomDetails: any
  id: string
}

export interface ClientNameLastname {
  value: string
}

export interface Subject {
  value: string
}

export interface WhoIsTheLastAnswer {
  value: string
}
