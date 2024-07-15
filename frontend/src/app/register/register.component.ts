import { HttpClient } from '@angular/common/http';
import { Component, inject, output, signal } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
 model:any;
 http = inject(HttpClient);
 cancelRegister  = output<boolean>();
 private toastr = inject(ToastrService);
 private accountService = inject(AccountService);

 register() {
  this.accountService.register(this.model).subscribe({
    next: _ => {
      this.cancel();
    },
    error : error => {
      this.toastr.error(error.error);
    }
  });
 }

 cancel() {
  this.cancelRegister.emit(false);
 }
}
