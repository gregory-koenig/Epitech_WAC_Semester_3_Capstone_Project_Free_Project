import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Answer } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class AnswerService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<Answer[]>(`${environment.apiUrl}/Answers`);
    }

    getById (id: number)
    {
        return this.http.get<Answer>(`${environment.apiUrl}/Answers/${id}`);
    }

    create (answer: Answer)
    {
        return this.http.post(`${environment.apiUrl}/Answers`, answer);
    }
    
    edit (answer: Answer)
    {
        return this.http.put(`${environment.apiUrl}/Answers/${answer.id}`, answer);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/Answers/${id}`);
    }
}
