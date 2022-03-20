import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  getMembers() {
    // todo: create an .env file to store the base url for endpoints.
    const endpoint = '/api/v1/members';
    // return this.http.get(endpoint);
    const members = [
      {
        "first_name": "Emma", 
        "last_name": "Dunham", 
        "date_of_birth": "31 Mar 1980", 
        "email_address": "emma.dunham@vtgrafix.gov", 
        "address": "76 Sherman Road", 
        "city": "Hastings", 
        "country": "Aruba", 
        "zip_code": "06830"
      }
    ];
    return members;
  }
}
