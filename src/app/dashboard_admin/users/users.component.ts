import { Component, OnInit } from '@angular/core';
import {User} from "@app/_models";
import {AlertService, UserService} from "@app/_services";
import {first} from "rxjs/operators";

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

    users: User[] = [];

    constructor(private userService: UserService, private alertService: AlertService) { }

    ngOnInit ()
    {
        this.userService.getAll().pipe(first()).subscribe(users =>
        {
            this.users = users;
        });
    }

    deleteUser (id: number)
    {
        this.userService.delete(id).pipe(first()).subscribe(
            data =>
            {
                this.alertService.success('Utilisateur supprimé', true);
                this.loadAllUsers();
            },
            error =>
            {
                this.alertService.error(error);
                this.loadAllUsers();
            });
    }


    private loadAllUsers ()
    {
        this.userService.getAll().pipe(first()).subscribe(users =>
        {
            this.users = users;
        });
    }

    ngOnDestroy ()
    {
        // unsubscribe to ensure no memory leaks
        // this.currentUserSubscription.unsubscribe();
    }

}
