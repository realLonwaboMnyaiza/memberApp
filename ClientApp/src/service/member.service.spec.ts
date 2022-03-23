import { componentFactoryName } from '@angular/compiler';
import { TestBed } from '@angular/core/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { Observable, from, of } from 'rxjs';
import { MemberDetailsComponent } from 'src/app/member-details/member-details.component';
import { Member } from 'src/model/Member';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { MemberService } from './member.service';

describe('MemberService', () => {
  let service: MemberService;
  let activatedRouteSpy;

  beforeEach(() => {
    activatedRouteSpy = {
      snapshot: {
        params: convertToParamMap({
          id: 1
        })
      }
    };
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: ActivatedRoute, useValue: activatedRouteSpy }
      ]
    });
    service = TestBed.inject(MemberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should populate member when component is loaded.', () => {
    // arrange.
    const component: MemberDetailsComponent = new MemberDetailsComponent(service, new ActivatedRoute);
    const member: Member = {
      id: 1,
      firstName: 'Lonawbo',
      lastName: 'Mnyaiza',
      dateOfBirth: '1992/07/19',
      email: 'lonwabo.mnyaiza@gmail.com',
      address: 'someplace',
      city: 'Cape Town',
      country: 'South Africa',
      zipCode: '7201'
    }
    spyOn(service, 'getMember').and.callFake((id: number) => {
      return from<Observable<Member>>(of(member));
    });

    // act.
    component.ngOnInit();

    // assert.
    expect(component.member).toBe(member);

  });
});
