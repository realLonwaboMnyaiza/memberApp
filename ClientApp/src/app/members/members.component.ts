import { Component, OnInit } from '@angular/core';
import { Member } from 'src/model/Member';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  private members : Member[];
  public membersFilter : Member[];
  
  constructor(private memberService: MemberService) {   }

  ngOnInit(): void {
    this.memberService
        .getMembers()
        .subscribe((data: Member[]) => {
          this.members = data;
          this.membersFilter = this.members;
        }, error => {
          // todo: can use global error handing, I think that uses an interceptor.
          console.error(error);
        });
  }

  filter(searchTerm: string): void {
    // note: should work, but need to find a cleaner way of doing this. 
    if (searchTerm) {
      this.membersFilter = this.members.filter(m => this.filterByNameAndSurname(m, searchTerm));
    } else {
      this.membersFilter = this.members;
    }
  }

  private filterByNameAndSurname(member: Member, searchTerm: string): boolean {
    const firstname = member.firstName.toLowerCase();
    const lastname = member.lastName.toLowerCase();
    return firstname.includes(searchTerm) 
          || lastname.includes(searchTerm);
  }
}
