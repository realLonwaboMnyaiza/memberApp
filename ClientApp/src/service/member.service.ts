import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  getMembers() {
    // todo: create an .env file to store the base url for endpoints.
    // const endpoint = '/api/v1/members';
    // return this.http.get(endpoint);
    // todo: getting cors issues
    // -> dummy the data out 
    // -> implement rendering of mock members in fe then go fix cors issues when fe can display data.
    const members = [
      {
        "firstName": "Emma", 
        "lastName": "Dunham", 
        "dateOfBirth": "31 Mar 1980", 
        "emailAddress": "emma.dunham@vtgrafix.gov", 
        "address": "76 Sherman Road", 
        "city": "Hastings", 
        "country": "Aruba", 
        "zipCode": "06830"
      },
      { 
        "firstName": "Ivan", 
        "lastName": "Risley", 
        "dateOfBirth": "09 Aug 1958", 
        "emailAddress": "ivan.risley@nitrosystems.co", 
        "address": "18 Hartswood Road", 
        "city": "Stanford", 
        "country": "Algeria", 
        "zipCode": "04346" 
      }, 
      { 
        "firstName": "Rikki", 
        "lastName": "Paquette", 
        "dateOfBirth": "18 Sep 1963", 
        "emailAddress": "rikki.paquette@anaplex.xyz", 
        "address": "56 Canal Street", 
        "city": "London", 
        "country": "Iceland", 
        "zipCode": "16935" 
      }, 
    ];
    return members;
  }
}
