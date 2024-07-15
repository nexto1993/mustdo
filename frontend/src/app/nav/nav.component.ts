import { Component, inject } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [RouterLinkActive,RouterLink, FormsModule, BsDropdownModule, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  model:any = {};
  accountService = inject(AccountService);
  router = inject(Router);
  toastr = inject(ToastrService);


  login() {
    this.accountService.login(this.model).subscribe( {
      next: _ => {
        this.router.navigateByUrl("/members");
      },
      error : error => {
        this.toastr.error(error.error);
      }
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
