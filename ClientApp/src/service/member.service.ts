import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from 'src/model/Member';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  // todo: create an .env file to store the base url for endpoints.
  private domain: string = 'https://localhost:7241';
  private resource: string = '/api/v1/members';
  private endpoint: string;

  constructor(private http: HttpClient) { 
    this.endpoint = `${this.domain}${this.resource}`;
  }

  getMember(id: number): Observable<Member> {
    return this.http.get<Member>(`${this.endpoint}/${id}`);
  }

  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.endpoint);
  }
}
