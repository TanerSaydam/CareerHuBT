import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-conversation',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './conversation.component.html',
  styleUrls: ['./conversation.component.css']
})
export class ConversationComponent implements OnDestroy {
  chatRoomId: string = "";
  whoAmI: string = "";
  chat: any;
  message: string = "";

  constructor(
    private activated: ActivatedRoute,
    private signalR: SignalRService,
    private http: HttpClient
  ){
    this.whoAmI = localStorage.getItem("whoAmI") as string;
    this.activated.params.subscribe(res=> {
      this.chatRoomId = res["value"];
      this.getAllConversation();  
      
      this.signalR.startConnection().then(()=> {
        this.signalR.joinRoom(this.chatRoomId);

        this.signalR.getChat((res:any)=> {          
            this.chat.chatRoomDetails.push(res);
        })
      });

      
    })
  }

  ngOnDestroy(): void {
    this.signalR.leaveRoom(this.chatRoomId);
  }

  getAllConversation(){
    this.http.post("https://livesupportwebapi.ecnorow.com/api/ChatRooms/GetAllChatRoomDetailByChatId", {chatRoomId: this.chatRoomId})
    .subscribe({
      next: (res: any)=> {
        this.chat = res;
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }

  sendMessage(){
    this.http.post("https://livesupportwebapi.ecnorow.com/api/ChatRooms/CreateANewMessage", {chatRoomId: this.chatRoomId, nameLastname: this.whoAmI, message: this.message})
    .subscribe({
      next: (res: any)=> {
        this.getAllConversation();  
        this.message = "";   
      },
      error: (err: HttpErrorResponse)=> {
        console.log(err);        
      }
    })
  }
}
