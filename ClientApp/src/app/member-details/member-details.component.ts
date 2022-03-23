import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/model/Member';
import { MemberService } from 'src/service/member.service';

@Component({
  selector: 'member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {
  isLoading = true;
  member : Member;

  constructor(private memberService: MemberService, 
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    const memberId = this.route.snapshot.params?.id;

    this.memberService
        .getMember(memberId)
        .subscribe((data: Member) => { 
          this.member = data;
          this.isLoading = false;
        }, error => {
          console.error(error);
          this.isLoading = false;
        });
  }
}
