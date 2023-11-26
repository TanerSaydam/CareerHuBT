import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr'

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor() { }

  hubConnection: signalR.HubConnection | any;

  startConnection(): Promise<void>{
    this.hubConnection = new signalR.HubConnectionBuilder()
                              .withUrl("https://livesupportwebapi.ecnorow.com/create-room-hub")
                              .build();

    return this.hubConnection
      .start()
      .then(()=> console.log("Connection started"))
      .catch((err:any)=> console.log(err));      
  }

  joinRoom(id: string){
    this.hubConnection.invoke("JoinChatRoomAsync", id);
  }

  leaveRoom(id: string){
    this.hubConnection.invoke("LeaveChatRoomAsync", id);
  }

  getCreatedRoomData = (callBack:any)=> {
    this.hubConnection.on("CreateRoom", (res:any)=> {
      callBack(res);
    })
  }

  getChat = (callBack:any) =>{
    this.hubConnection.on("Chat", (res:any)=> {
      callBack(res);
    })
  }
}
