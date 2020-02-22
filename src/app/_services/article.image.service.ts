import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { ArticleImage } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class ArticleImageService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<ArticleImage[]>(`${environment.apiUrl}/ArticleImages`);
    }

    getById (id: number)
    {
        return this.http.get<ArticleImage>(`${environment.apiUrl}/ArticleImages/${id}`);
    }

    create (articleImage: ArticleImage)
    {
        return this.http.post(`${environment.apiUrl}/ArticleImages`, articleImage);
    }

    edit (articleImage: ArticleImage)
    {
        return this.http.put(`${environment.apiUrl}/ArticleImages/${articleImage.id}`, articleImage);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/ArticleImages/${id}`);
    }
}
