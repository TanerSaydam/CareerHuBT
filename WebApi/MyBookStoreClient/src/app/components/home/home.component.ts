import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingCardService } from '../../services/shopping-card.service';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { BookModel } from 'src/app/models/book.model';
import { HttpClient } from '@angular/common/http';
import { RequestModel } from 'src/app/models/request.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, InfiniteScrollModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  books: BookModel[] = []
  carousel: BookModel[] = [];
  scrollDistance = 1;
  scrollUpDistance = 2;
  throttle = 300;
  request: RequestModel = new RequestModel();
  
  constructor(
    private shopping: ShoppingCardService,
    private http: HttpClient
  ) {
    this.getAllBook();
  }

  addShoppingCard(book: BookModel) {
   this.shopping.add(book)
  }

  

  onScrollDown(): void { 
    this.request.pageSize += 12;   
    this.getAllBook();
  }

  getAllBook(): void {
    this.http.post<any>("https://localhost:7062/api/Books/GetAllForUserUI", this.request)
    .subscribe(res=> {
      this.books = res;
      for (let i = 0; i < (res.length >= 3 ? 3 : res.length); i++) {
        this.carousel.push(this.books[i]);

        
      }
    })
  }
}
