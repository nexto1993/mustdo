import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { User } from './_models/User';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  
  http = inject(HttpClient);
  accountSerrvice = inject(AccountService);
  title = 'client';
  users: any;
  ngOnInit(): void
  {
    this.setCurrentUser();
  }


  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) {
     return;
    }
    const user: User = JSON.parse(userString);
    this.accountSerrvice.currentUser.set(user);
  }
 

}
