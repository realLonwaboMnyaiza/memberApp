import { Component, OnInit } from '@angular/core';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  // todo: use model.
  public member : any;

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.member = this.memberService.getMembers()
      console.log(this.member);
  }
}
