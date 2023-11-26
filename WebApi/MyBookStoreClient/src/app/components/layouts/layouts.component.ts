import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ShoppingCardService } from '../../services/shopping-card.service';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink],
  templateUrl: './layouts.component.html',
  styleUrls: ['./layouts.component.css']
})
export class LayoutsComponent {
  constructor(
    public shopping: ShoppingCardService
  ){}
}
