import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Poll } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class PollService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Poll[]>(`${environment.apiUrl}/Polls`);
    }

    getById (id: number)
    {
        return this.http.get<Poll>(`${environment.apiUrl}/Polls/${id}`);
    }

    create (poll: Poll)
    {
        return this.http.post(`${environment.apiUrl}/Polls`, poll);
    }

    edit (poll: Poll)
    {
        return this.http.put(`${environment.apiUrl}/Polls/${poll.id}`, poll);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/Polls/${id}`);
    }
}
