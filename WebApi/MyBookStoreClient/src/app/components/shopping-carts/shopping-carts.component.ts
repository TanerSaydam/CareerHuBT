import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingCardService } from 'src/app/services/shopping-card.service';

@Component({
  selector: 'app-shopping-carts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './shopping-carts.component.html',
  styleUrls: ['./shopping-carts.component.css']
})
export class ShoppingCartsComponent {
constructor(
  public shopping: ShoppingCardService
){}
}
