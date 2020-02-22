import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Image } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class ImageService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Image[]>(`${environment.apiUrl}/Images`);
    }

    getById (id: number)
    {
        return this.http.get<Image>(`${environment.apiUrl}/Images/${id}`);
    }

    create (image: Image)
    {
        return this.http.post(`${environment.apiUrl}/Images`, image);
    }

    edit (image: Image)
    {
        return this.http.put(`${environment.apiUrl}/Images/${image.id}`, image);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/Images/${id}`);
    }
}
