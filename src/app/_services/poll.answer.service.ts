import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { PollAnswer } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class PollAnswerService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<PollAnswer[]>(`${environment.apiUrl}/PollAnswers`);
    }

    getById (id: number)
    {
        return this.http.get<PollAnswer>(`${environment.apiUrl}/PollAnswers/${id}`);
    }

    create (pollAnswer: PollAnswer)
    {
        return this.http.post(`${environment.apiUrl}/pollAnswers`, pollAnswer);
    }

    edit (pollAnswer: PollAnswer)
    {
        return this.http.put(`${environment.apiUrl}/PollAnswers/${pollAnswer.id}`, pollAnswer);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/PollAnswers/${id}`);
    }
}
