import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { TableModel } from '../home/home.component';
import { TrCurrencyPipe } from 'tr-currency';
import { HttpClient } from '@angular/common/http';
import { OrderLoadingComponent } from '../order-loading/order-loading.component';
import { LazyLoadImageModule } from 'ng-lazyload-image';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, TrCurrencyPipe, RouterLink, OrderLoadingComponent, LazyLoadImageModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export default class OrderComponent {
  tableId: string = "";  
  tableNumber: number = 0;


  id: number = 0;
  products: ProductModel[] = [
    {
      id: "1",
      name: "Classic Burger",
      coverImage: "/assets/classic-burger.png",
      price: 60,
      category: "Ana Yemek",
    },
    {
      id: "2",
      name: "Classic Hot Dog",
      coverImage: "/assets/classic-hot-dog.png",
      price: 430,
      category: "Ara Yemek"
    },
    {
      id: "3",
      name: "Crispy Fried Chicken",
      coverImage: "/assets/crispy-fried-chicken.png",
      price: 100,
      category: "Ana Yemek"
    },
    {
      id: "4",
      name: "Ice Cream",
      coverImage: "/assets/ice-cream.png",
      price: 150,
      category: "Salata"
    },
    {
      id: "5",
      name: "Sandwich",
      coverImage: "/assets/sandwich.png",
      price: 450,
      category: "Aparatif"
    },
    {
      id: "6",
      name: "Soft Drink",
      coverImage: "/assets/soft-drink.png",
      price: 250,
      category: "İçecek"
    },
    {
      id: "7",
      name: "Taco",
      coverImage: "/assets/taco.png",
      price: 450,
      category: "Atıştırmalık"
    }
  ]
  orders: OrderModel[] = [];
  total: number = 0;

  constructor(
    private activated: ActivatedRoute,
    private http: HttpClient
  ){
    this.activated.params.subscribe(res=> {
      this.tableId = res["value"];
      this.getTableNumberById();
    })
  }

  getTableNumberById(){
    this.http
    .post("https://localhost:7298/api/Tables/GetNumberById",{id: this.tableId})
    .subscribe((res:any)=> this.tableNumber = res.number)
  }

  addOrder(product: any){   
    this.id++; //bunu kaldıracağız

    const order = new OrderModel();
    order.id = this.id.toString();
    order.price = product.price;
    order.productId = product.id;
    order.product = product;

    order.status = OrderStatusEnum.SiparişAlındı; 
    this.orders.push(order);

    this.total += product.price;
  }

  removeOrder(id: string){
    const index = this.orders.findIndex(p=> p.id == id);
    if(index >= 0){
      this.total -= this.orders[index].price;
      this.orders.splice(index,1)
    }
  }

  changeOrderStatusClass(status: OrderStatusEnum){
    if(status === OrderStatusEnum.SiparişAlındı)
      return "text-danger"
    else if(status === OrderStatusEnum.Hazırlanıyor)
      return "text-warning"
    else
      return "text-success"
  }

  changeOrderStatus(id: string){
    const index = this.orders.findIndex(p=> p.id == id);
    if(index >= 0){
      const order = this.orders[index];
      switch (order.status) {
        case OrderStatusEnum.SiparişAlındı:
          order.status = OrderStatusEnum.Hazırlanıyor
          break;
      
        case OrderStatusEnum.Hazırlanıyor:
          order.status = OrderStatusEnum.MasayaTeslimEdildi
          break;

        default:
          order.status = OrderStatusEnum.SiparişAlındı
          break;
      }
    }
  }
}

export class ProductModel{
  id: string = "";
  name: string = "";
  price: number = 0;
  coverImage: string = "";
  category: string = "";
}

export class OrderModel{  
  id: string = "";
  productId: string = "";
  product: ProductModel = new ProductModel();
  price: number = 0;
  status: OrderStatusEnum = OrderStatusEnum.SiparişAlındı;
}


export enum OrderStatusEnum{
  SiparişAlındı = "Sipariş Alındı",
  Hazırlanıyor = "Hazırlanıyor",
  MasayaTeslimEdildi = "Masaya Teslim Edildi"
}