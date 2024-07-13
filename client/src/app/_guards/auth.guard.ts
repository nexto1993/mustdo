import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toasterService = inject(ToastrService);
  if(accountService.currentUser()) {
    return true;
  }
  else {
    toasterService.error('You are not authorized to access this page');
    return false;
  }
};
