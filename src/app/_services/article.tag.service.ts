import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { ArticleTag } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class ArticleTagService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<ArticleTag[]>(`${environment.apiUrl}/ArticleTags`);
    }

    getById (id: number)
    {
        return this.http.get<ArticleTag>(`${environment.apiUrl}/ArticleTags/${id}`);
    }

    create (articleTag: ArticleTag)
    {
        return this.http.post(`${environment.apiUrl}/ArticleTags`, articleTag);
    }

    edit (articleTag: ArticleTag)
    {
        return this.http.put(`${environment.apiUrl}/ArticleTags/${articleTag.id}`, articleTag);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/ArticleTags/${id}`);
    }
}
