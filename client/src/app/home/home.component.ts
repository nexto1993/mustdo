import { Component, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
 registerMode = false;
 http = inject(HttpClient);
  users:any;
    constructor() { }
  
    ngOnInit() {
      this.getUsers();
    }
  
    registerToggle() {
      this.registerMode = !this.registerMode;
    }
  
    cancelRegisterMode(event: boolean) {
      this.registerMode = event;
    }
    getUsers() {
      this.http.get('https://localhost:7287/api/users').subscribe({
        next: (data) => {
          this.users = data;
          console.log(data);
        },
        error: (error) => {
          console.error('There was an error!', error);
        },
        complete: () => {
          console.log('Completed');
        }
      });
    }
}
