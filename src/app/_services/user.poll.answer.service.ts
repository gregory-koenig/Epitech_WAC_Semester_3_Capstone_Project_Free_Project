import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { UserPollAnswer } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class UserPollAnswerService
{
    constructor(private http: HttpClient) { }

    getAll ()
    {
        return this.http.get<UserPollAnswer[]>(`${environment.apiUrl}/UserPollAnswers`);
    }

    getById (id: number)
    {
        return this.http.get<UserPollAnswer>(`${environment.apiUrl}/UserPollAnswers/${id}`);
    }

    create (userPollAnswer: UserPollAnswer)
    {
        return this.http.post(`${environment.apiUrl}/UserPollAnswers`, userPollAnswer);
    }

    edit (userPollAnswer: UserPollAnswer)
    {
        return this.http.put(`${environment.apiUrl}/UserPollAnswers/${userPollAnswer.id}`, userPollAnswer);
    }

    delete (id: number)
    {
        return this.http.delete(`${environment.apiUrl}/UserPollAnswers/${id}`);
    }
}
