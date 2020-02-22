import {RouterModule, Routes} from '@angular/router';

import {LoginComponent} from './login';
import {AuthGuard} from './_guards';
import {PrivacyComponent} from './privacy/privacy.component';
import {Role} from './_models';
import {UsersComponent} from "@app/dashboard_admin/users/users.component";
import {CreateUserComponent} from "@app/dashboard_admin/users/create-user/create-user.component";
import {EditUserComponent} from "@app/dashboard_admin/users/edit-user/edit-user.component";
import {DashboardHomepageComponent} from "@app/dashboard_admin/dashboard-homepage/dashboard.homepage.component";
import {HomepageComponent} from "@app/homepage/homepage.component";
import {ArticleComponent} from "@app/article/article.component";
import {DashboardArticleComponent} from "@app/dashboard_admin/dashboard-article/dashboard-article.component";
import {CreateArticleComponent} from "@app/dashboard_admin/dashboard-article/create-article/create-article.component";

const appRoutes: Routes = [
	{
		path: '',
		component: HomepageComponent
	},
	{
		path: 'login',
		component: LoginComponent,
	},
	{
		path: 'privacy',
		component: PrivacyComponent
	},
	{
		path: 'admin',
		component: DashboardHomepageComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	{
		path: 'admin/users',
		component: UsersComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	{
		path: 'admin/users/create',
		component: CreateUserComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	{
		path: 'admin/users/edit/:id',
		component: EditUserComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	{
		path: 'articles/:id',
		component: ArticleComponent
	},
	{
		path: 'admin/articles',
		component: DashboardArticleComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	{
		path: 'admin/articles/create',
		component: CreateArticleComponent,
		canActivate: [AuthGuard],
		data: { roles: [Role.Admin] }
	},
	
	
	// otherwise redirect to home
	{ path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
