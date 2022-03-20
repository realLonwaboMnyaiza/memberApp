import { Component, OnInit } from '@angular/core';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {
  // todo: use model.
  public member : any;

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.member = this.memberService.getMembers()
      console.log(this.member);
  }
}
