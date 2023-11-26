import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BalloonService } from 'src/app/services/balloon.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  counter: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]

  constructor(
    private balloon: BalloonService
  ){
    this.balloon.shoCommentBalloon = true;
  }
}
