import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MemberCardComponent } from './member-card/member-card.component';
import { MemberService } from 'src/service/member.service';
import { MemberDetailsComponent } from './member-details/member-details.component';
import { MembersComponent } from './members/members.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    MemberCardComponent,
    MemberDetailsComponent,
    MembersComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'members', component: MembersComponent},
      { path: 'about', component: AboutComponent},
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
    MemberService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
