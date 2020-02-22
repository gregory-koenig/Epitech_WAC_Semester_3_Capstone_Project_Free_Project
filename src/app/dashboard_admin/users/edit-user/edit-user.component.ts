import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {User} from "@app/_models";
import {ActivatedRoute, Router} from "@angular/router";
import {AlertService, UserService} from "@app/_services";
import {first} from "rxjs/operators";

@Component({
    selector: 'app-edit-user',
    templateUrl: './edit-user.component.html',
    styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

    public userId = parseInt(this.route.snapshot.paramMap.get('id'));
    public registerForm: FormGroup;
    public loading = false;
    public submitted = false;
    public users: User[] = [];

    constructor(private route: ActivatedRoute,
                private formBuilder: FormBuilder,
                private userService: UserService,
                private alertService: AlertService,
                private router: Router) {
    }

    ngOnInit() {
        this.userService.getById(this.userId).pipe(first()).subscribe(u => {
            this.registerForm = this.formBuilder.group({
                firstName: [u.firstName, Validators.required],
                lastName: [u.lastName, Validators.required],
                username: [u.username, Validators.required],
                password: [u.password, [Validators.required, Validators.minLength(6)]],
                mail: [u.mail, []],
                phone: [u.phone, []],
                role: [u.role, [Validators.required]]
            });
        });
        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]],
            mail: ['', []],
            phone: ['', []],
            role: ['', [Validators.required]]
        });
    }

    get f () { return this.registerForm.controls; }

    onSubmit ()
    {
        this.submitted = true;

        // stop here if form is invalid
        if (this.registerForm.invalid)
        {
            console.log("unvalid")
            return;
        }

        this.loading = true;
        this.userService.update(this.registerForm.value, this.userId)
            .pipe(first())
            .subscribe(
                data =>
                {
                    this.alertService.success('Utilisateur modifié', true);
                    this.router.navigate(['/admin/users']);
                },
                error =>
                {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }

}
