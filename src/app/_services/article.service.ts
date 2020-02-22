import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Article } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class ArticleService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Article[]>(`${environment.apiUrl}/Articles`);
    }

    getById (id: number)
    {
        return this.http.get<Article>(`${environment.apiUrl}/Articles/${id}`);
    }

    create (article: Article)
    {
        return this.http.post(`${environment.apiUrl}/Articles`, article);
    }

    edit (article: Article)
    {
        return this.http.put(`${environment.apiUrl}/Articles/${article.id}`, article);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/Articles/${id}`);
    }
}
