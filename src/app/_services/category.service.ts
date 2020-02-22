import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Category } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class CategoryService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Category[]>(`${environment.apiUrl}/categories`);
    }

    getById (id: number)
    {
        return this.http.get<Category>(`${environment.apiUrl}/categories/${id}`);
    }

    create (category: Category)
    {
        return this.http.post(`${environment.apiUrl}/categories`, category);
    }

    edit (category: Category)
    {
        return this.http.put(`${environment.apiUrl}/categories/${category.id}`, category);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/categories/${id}`);
    }
}
