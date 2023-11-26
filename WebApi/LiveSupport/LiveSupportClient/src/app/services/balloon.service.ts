import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BalloonService {
  showCommentDiv: boolean = false;
  shoCommentBalloon: boolean = false;
  
  constructor() { }
}
