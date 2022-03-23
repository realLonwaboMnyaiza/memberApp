import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from 'src/model/Member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  getMembers() {
    // todo: create an .env file to store the base url for endpoints.
    const domain = 'https://localhost:7241';
    const resource = '/api/v1/members';
    const endpoint = `${domain}${resource}`;
    return this.http.get<Member[]>(endpoint);
  }
}
