import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../_services';
import { User, Role } from '../_models';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})

export class NavbarComponent implements OnInit {
  currentUser: User;

  constructor(private router: Router, private authenticationService: AuthenticationService) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {

  }

  get isAdmin () {
      return this.currentUser && this.currentUser.role === Role.Admin;
  }

  get isUser () {
      return this.currentUser && this.currentUser.role === Role.User;
  }

  get isClient () {
      return this.currentUser && this.currentUser.role === Role.Client;
  }

    logout () {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
  }

  export class MenuIconsExample {}
