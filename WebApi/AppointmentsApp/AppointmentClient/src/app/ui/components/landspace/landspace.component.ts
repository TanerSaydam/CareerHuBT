import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-landspace',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './landspace.component.html',
  styleUrls: ['./landspace.component.css']
})
export class LandspaceComponent {

}
