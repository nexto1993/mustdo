import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  baseUrl = 'https://localhost:7287/api/';

  login(model:any) {
    return this.http.post(this.baseUrl + "Account/login", model);
  }
}
