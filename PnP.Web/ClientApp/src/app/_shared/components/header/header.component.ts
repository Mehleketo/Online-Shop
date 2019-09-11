import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AccountsService } from '../../../_services/accounts.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    private accountsService: AccountsService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onLogoutClick() {
    this.accountsService.logout();
    this.router.navigate(['/signin']);
    return false;
  }
}
