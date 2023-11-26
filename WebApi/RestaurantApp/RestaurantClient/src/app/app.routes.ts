import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: "",
        loadComponent: ()=> import("./components/home/home.component")
    },
    {
        path: "order/:value",
        loadComponent:()=> import("./components/order/order.component")
    }
];
