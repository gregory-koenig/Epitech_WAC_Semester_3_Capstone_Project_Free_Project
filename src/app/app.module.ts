import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';

import { AlertComponent } from './_components';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { PrivacyComponent } from './privacy/privacy.component';
import {LoadingBarHttpClientModule} from "@ngx-loading-bar/http-client";
import { FormsModule } from '@angular/forms';
import { HomepageComponent } from '@app/homepage/homepage.component';
import {UsersComponent} from "@app/dashboard_admin/users/users.component";
import {CreateUserComponent} from "@app/dashboard_admin/users/create-user/create-user.component";
import {EditUserComponent} from "@app/dashboard_admin/users/edit-user/edit-user.component";
import {SidebarComponent} from "@app/dashboard_admin/sidebar/sidebar.component";
import {StatsComponent} from "@app/dashboard_admin/stats/stats.component";
import {DashboardHomepageComponent} from "@app/dashboard_admin/dashboard-homepage/dashboard.homepage.component";
import {NavbarComponent} from "@app/navbar/navbar.component";
import {DashboardNavbarComponent} from "@app/dashboard_admin/dashboard-navbar/dashboard.navbar.component";
import { ArticleComponent } from './article/article.component';
import {MatIconModule, MatMenuModule} from "@angular/material";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {DashboardArticleComponent} from "@app/dashboard_admin/dashboard-article/dashboard-article.component";
import {CreateArticleComponent} from "@app/dashboard_admin/dashboard-article/create-article/create-article.component";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing,
        LoadingBarHttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        MatMenuModule,
        MatIconModule,
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent,
        PrivacyComponent,
        HomepageComponent,
        UsersComponent,
        CreateUserComponent,
        EditUserComponent,
        NavbarComponent,
        SidebarComponent,
        StatsComponent,
        DashboardHomepageComponent,
        DashboardNavbarComponent,
        ArticleComponent,
        DashboardArticleComponent ,
        CreateArticleComponent,   ],
    
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
