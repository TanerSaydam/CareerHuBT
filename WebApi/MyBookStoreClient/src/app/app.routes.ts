import { Routes } from '@angular/router';
import { LayoutsComponent } from './components/layouts/layouts.component';
import { HomeComponent } from './components/home/home.component';
import { ShoppingCartsComponent } from './components/shopping-carts/shopping-carts.component';

export const routes: Routes = [
    {
        path: "",
        component: LayoutsComponent,
        children: [
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "shopping-carts",
                component: ShoppingCartsComponent
            }
        ]
    }
];
