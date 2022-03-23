import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/model/Member';

@Component({
  selector: 'member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {

  // todo: can ini this obj or turn off strictPropertyInitialization.
  // -> rn easier to use non-null assertion.
  @Input() member!: Member;

  constructor() { }

  ngOnInit(): void {
    this.member.dateOfBirth = 
          new Date(this.member.dateOfBirth)
          .toLocaleDateString();
  }
}
