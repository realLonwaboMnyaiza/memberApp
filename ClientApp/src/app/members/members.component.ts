import { Component, OnInit } from '@angular/core';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  // todo: use member model.
  public members : any;
  
  constructor(private memberService: MemberService) {   }

  ngOnInit(): void {
    this.members = this.memberService.getMembers();
  }

  filter(searchTerm: string) {
    console.log(searchTerm);
  }
}
