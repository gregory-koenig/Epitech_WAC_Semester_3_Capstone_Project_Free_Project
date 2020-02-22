import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Tag } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class TagService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Tag[]>(`${environment.apiUrl}/Tags`);
    }

    getById (id: number)
    {
        return this.http.get<Tag>(`${environment.apiUrl}/Tags/${id}`);
    }

    create (tag: Tag)
    {
        return this.http.post(`${environment.apiUrl}/Tags`, tag);
    }

    edit (tag: Tag)
    {
        return this.http.put(`${environment.apiUrl}/Tags/${tag.id}`, tag);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/Tags/${id}`);
    }
}
