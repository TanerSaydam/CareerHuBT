import { MoneyModel } from "./money.model";

export class BookModel{
    id: string = "";
    name: string = "";
    dailyPrice: MoneyModel = new MoneyModel();
    summary: string = "";
    author: string = "";
    publishDate: string = "";
    imageUrl: string = "";
    quantity:number = 0;    
}