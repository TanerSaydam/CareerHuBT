import { Routes } from '@angular/router';
import { LandspaceComponent } from './ui/components/landspace/landspace.component';
import { AppointmentComponent } from './ui/components/appointment/appointment.component';

export const routes: Routes = [
    {
        path: "",
        component: LandspaceComponent
    },
    {
        path: "appointment",
        component: AppointmentComponent
    }
];
