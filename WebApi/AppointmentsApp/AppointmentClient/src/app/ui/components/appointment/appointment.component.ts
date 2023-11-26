import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  providers: [DatePipe],
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {
  hours: number[] = [];
  appointments: Appointment[] = [];
  selectedWeeks: Week[] = [];
  week: string = "";

  appointment: Appointment = new Appointment();
  constructor(
    private http: HttpClient,
    private date: DatePipe
  ) {
    this.selectedWeeks = this.getCurrentWeekDays();

    for (let i = 0; i < 24; i++) {
      this.hours.push(i)
    }
  }

  ngOnInit(): void {
    this.getAllAppointments();
  }  
  
  getAllAppointments(){
    this.http.post<Appointment[]>("https://localhost:7293/api/Appointments/GetAppointments", {startDate: this.selectedWeeks[0].date, endDate: this.selectedWeeks[6].date})
    .subscribe(res=> {
      this.appointments = res;
      this.appointments.forEach((value)=> {
        value.date = this.date.transform(value.date, 'dd.MM.yyyy');
      })
    })
  }

  getPatient(hour: number, date: string) {
    const patient = this.appointments.filter(p => p.hour == hour && p.date === date)[0]?.patient

    return patient;
  }

  getAppointment(hour: number, date: string) {
    const currentAppointment = this.appointments.find(p => p.hour === hour && p.date === date);
    this.appointment = new Appointment();
    if (currentAppointment) {
      this.appointment.patient = { ...currentAppointment.patient };
    }
    this.appointment.hour = hour;
    this.appointment.date = date;
  }

  setAppointment() {
    this.http.post("https://localhost:7293/api/Appointments/SetOrChangeAppointment", this.appointment)
    .subscribe(()=> {
      this.getAllAppointments();
    })
  }

  getCurrentWeekDays(): Week[] {
    // Mevcut tarih için bir Date objesi oluşturuyoruz
    const currentDate = new Date();

    // Mevcut haftanın pazartesi tarihini buluyoruz
    const dayOffset = currentDate.getDay() === 0 ? 6 : currentDate.getDay() - 1; // Eğer gün pazar ise offset 6, değilse gün-1
    const monday = new Date(currentDate);
    monday.setDate(currentDate.getDate() - dayOffset);

    // Mevcut haftanın her bir günü için tarihler
    const weekDays: Week[] = [];

    for (let i = 0; i < 7; i++) {
      let dayName: string = "";
      switch (i) {
        case 0:
          dayName = "Pazartesi"
          break;
        case 1:
          dayName = "Salı"
          break;
        case 2:
          dayName = "Çarşamba"
          break;
        case 3:
          dayName = "Perşembe"
          break;
        case 4:
          dayName = "Cuma"
          break;
        case 5:
          dayName = "Cumartesi"
          break;
        case 6:
          dayName = "Pazar"
          break;
        default:
          break;
      }


      const currentDay = new Date(monday);
      currentDay.setDate(monday.getDate() + i);
      weekDays.push({date: `${currentDay.getDate()}.${currentDay.getMonth() + 1}.${currentDay.getFullYear()}`, dayName: dayName});
    }

    return weekDays;
  }

  changeSelectedWeek() {  
    
    const [year, week] = this.week.split('-W');

    // Yılın ilk günü için bir Date objesi oluşturuyoruz
    const firstDayOfYear = new Date(Number(year), 0, 1);

    // Pazartesiye göre ayarlıyoruz
    const dayOffset = firstDayOfYear.getDay() <= 4 ? firstDayOfYear.getDay() - 1 : firstDayOfYear.getDay() - 1 - 7;

    // Pazartesi tarihini buluyoruz
    const firstMonday = new Date(firstDayOfYear);
    firstMonday.setDate(firstDayOfYear.getDate() - dayOffset);

    // Seçilen haftanın pazartesi tarihini buluyoruz
    const selectedMonday = new Date(firstMonday);
    selectedMonday.setDate(firstMonday.getDate() + (Number(week) - 1) * 7);

    // Seçilen haftanın her bir günü için tarihler
    const weekDays: Week[] = [];

    for (let i = 0; i < 7; i++) {
      let dayName: string = "";
      switch (i) {
        case 0:
          dayName = "Pazartesi"
          break;
        case 1:
          dayName = "Salı"
          break;
        case 2:
          dayName = "Çarşamba"
          break;
        case 3:
          dayName = "Perşembe"
          break;
        case 4:
          dayName = "Cuma"
          break;
        case 5:
          dayName = "Cumartesi"
          break;
        case 6:
          dayName = "Pazar"
          break;
        default:
          break;
      }

      const currentDay = new Date(selectedMonday);

      currentDay.setDate(selectedMonday.getDate() + i);

      // Tarih ve ay için iki basamaklı hale getiriyoruz
      const paddedDate = String(currentDay.getDate()).padStart(2, '0');
      const paddedMonth = String(currentDay.getMonth() + 1).padStart(2, '0');

      currentDay.setDate(selectedMonday.getDate() + i);
      weekDays.push({ date: `${paddedDate}.${paddedMonth}.${currentDay.getFullYear()}`, dayName: dayName});      
    }
    this.selectedWeeks = weekDays;

    this.getAllAppointments();
  }

  cancelAppointment(hour: number, date: string){
    const currentAppointment:any = this.appointments.find(p => p.hour === hour && p.date === date);
    this.http
    .get(`https://localhost:7293/api/Appointments/CancelAppointmentById/${currentAppointment.id}`)
    .subscribe(()=> {
      this.getAllAppointments();
    })
  }

  findPatientByIdentityNumber(){
    this.http.get<Patient | null>(`https://localhost:7293/api/Appointments/GetPatientByIdentityNumber/${this.appointment.patient.identityNumber}`)
    .subscribe(res=> {
      if(res !== null){
        this.appointment.patient = {...res};
      }
    })
  }
}

export class Appointment {
  id: string = "";
  date: string | null = "";
  hour: number = 0;
  patient: Patient = new Patient();
}

export class Patient {
  id: string = "";
  name: string = "";
  identityNumber: string = "";
  phoneNumber: string = "";
  email: string = "";
}


export class Week {
  date: string = "";
  dayName: string = "";
}


