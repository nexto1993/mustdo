import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:7287/api/";
  http = inject(HttpClient);
  currentUser = signal<User|null>(null);


  login(model:any) {
    return this.http.post<User>(this.baseUrl + "Account/login", model).pipe(

      map(response => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
    
  }

  register(model:any) {
    return this.http.post<User>(this.baseUrl + "account/register", model).pipe(

      map(response => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
