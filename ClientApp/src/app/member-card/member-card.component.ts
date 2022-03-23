import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/model/Member';
import { Router } from '@angular/router';

@Component({
  selector: 'member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  displayMemberDetails() {
    this.router.navigateByUrl(`/members/${this.member.id}`);
  }
}
