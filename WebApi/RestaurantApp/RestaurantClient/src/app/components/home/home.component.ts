import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export default class HomeComponent implements OnInit {
  tables: TableModel[] = []

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getAll();
  }


  getAll(){
    this.http.post<TableModel[]>("https://localhost:7298/api/Tables/GetAll",{}).subscribe(res=> this.tables = res);
  }
}


export class TableModel{
  id: string = "";
  number: number = 1;
  isAvailable: boolean = true;
  amount: number = 0;
}