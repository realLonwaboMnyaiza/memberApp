import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {

  @Input() member: any;

  constructor() { }

  ngOnInit(): void {
  }
}
