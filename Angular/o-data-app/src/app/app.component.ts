import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular';
import { HttpClient } from '@angular/common/http';
import { GridOptions, GridReadyEvent } from 'ag-grid-community';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, AgGridModule ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  rowData: any = [];
  gridApi: any;
  columnApi: any;

  colDefs: any[] = [
    {
      field: "firstName",
      filter: true
    },
    {
      field: "lastName",
      filter: true
    },
    {
      field: "email",
      filter: true,
      filterParams: {
        // can be 'windows' or 'mac'
        excelMode: 'windows',
    },
    },
    {
      field: "operations",

    }
  ];

  gridOptions:GridOptions = {
    pagination: true,
    paginationPageSize: 10
  };

  constructor(
    private http: HttpClient
  ) {
    this.getAll();
  }

  getAll() {
    this.http.get("https://localhost:7089/api/Values/GetAll").subscribe(res => {
      this.rowData = res;
    })
  }

  onGridReady(params: GridReadyEvent<any>) {
    console.log(params);
    
    this.http.get("https://localhost:7089/api/Values/GetAll").subscribe(res => {
      this.rowData = res;
    })
  }

  onBtExport() {
    this.gridApi.exportDataAsExcel();
  }

}
