import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { DashBoardComponent } from './Pages/dash-board/dash-board.component';
import { UserComponent } from './Pages/user/user.component';
import { ClientComponent } from './Pages/client/client.component';
import { EmailComponent } from './Pages/email/email.component';
import { EmailLogComponent } from './Pages/email-log/email-log.component';
import { ReportComponent } from './Pages/report/report.component';
import { SharedModule } from 'src/app/Reusable/shared/shared.module';


@NgModule({
  declarations: [
    DashBoardComponent,
    UserComponent,
    ClientComponent,
    EmailComponent,
    EmailLogComponent,
    ReportComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule
  ]
})
export class LayoutModule { }
