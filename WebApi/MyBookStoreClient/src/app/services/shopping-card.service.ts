import { Injectable } from '@angular/core';
import { BookModel } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCardService {
  count: number = 0;
  shoppingCarts: BookModel[] = [];
  constructor() {
    this.getCount()
   }

  add(book: BookModel){
    this.shoppingCarts.push(book);
    localStorage.setItem("shoppingCarts", JSON.stringify(this.shoppingCarts));
    this.count = this.shoppingCarts.length;
  }

  getCount(){
    if(localStorage.getItem("shoppingCarts")){
      const responeString:any = localStorage.getItem("shoppingCarts");
      const response = JSON.parse(responeString);
      this.shoppingCarts = response;
      this.count = this.shoppingCarts.length;
    } 
  }
}
