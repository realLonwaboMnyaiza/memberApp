import { Component, OnInit } from '@angular/core';
import { Member } from 'src/model/Member';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  private members : Member[] = [];
  public membersFilter : Member[] = [];
  
  constructor(private memberService: MemberService) {   }

  ngOnInit(): void {
    this.members = this.memberService.getMembers();
    this.membersFilter = this.members;
  }

  filter(searchTerm: string) {
    // todo: should work, but need to find a cleaner way of doing this. 
    if (searchTerm) {
      this.membersFilter = this.members.filter(m => m.firstName.toLowerCase().includes(searchTerm.toLowerCase()));
    } else {
      this.membersFilter = this.members;
    }
  }
}
