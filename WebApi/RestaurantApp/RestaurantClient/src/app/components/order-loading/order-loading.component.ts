import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductModel } from '../order/order.component';

@Component({
  selector: 'app-order-loading',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './order-loading.component.html',
  styleUrl: './order-loading.component.css'
})
export class OrderLoadingComponent {
  products: ProductModel[] = [
    {
      id: "1",
      name: "Classic Burger",
      coverImage: "/assets/product-placeholder.png",
      price: 60,
      category: "Ana Yemek",
    },
    {
      id: "2",
      name: "Classic Hot Dog",
      coverImage: "/assets/product-placeholder.png",
      price: 430,
      category: "Ara Yemek"
    },
    {
      id: "3",
      name: "Crispy Fried Chicken",
      coverImage: "/assets/product-placeholder.png",
      price: 100,
      category: "Ana Yemek"
    },
    {
      id: "4",
      name: "Ice Cream",
      coverImage: "/assets/product-placeholder.png",
      price: 150,
      category: "Salata"
    },
    {
      id: "5",
      name: "Sandwich",
      coverImage: "/assets/product-placeholder.png",
      price: 450,
      category: "Aparatif"
    },
    {
      id: "6",
      name: "Soft Drink",
      coverImage: "/assets/product-placeholder.png",
      price: 250,
      category: "İçecek"
    },
    {
      id: "7",
      name: "Taco",
      coverImage: "/assets/product-placeholder.png",
      price: 450,
      category: "Atıştırmalık"
    }
  ]
}
