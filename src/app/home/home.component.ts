import {Component, OnInit, OnDestroy} from '@angular/core';
import {first} from 'rxjs/operators';

import {User, Role} from '@app/_models';
import {UserService, AuthenticationService} from '@app/_services';

@Component({templateUrl: 'home.component.html'})
export class HomeComponent implements OnInit, OnDestroy {
    currentUser: User;
    userFromApi: User;

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService)
    {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.userService.getById(this.currentUser.id).pipe(first()).subscribe(user => {
            this.userFromApi = user;
        });
    }

    get isAdmin() {
        return this.currentUser && this.currentUser.role === Role.Admin;
    }

    get isUser() {
        return this.currentUser && this.currentUser.role === Role.User;
    }

    log() {
        console.log("UserFromAPI: ", this.currentUser);
    }

    ngOnDestroy() {
        // unsubscribe to ensure no memory leaks
        // this.currentUserSubscription.unsubscribe();
    }
}
