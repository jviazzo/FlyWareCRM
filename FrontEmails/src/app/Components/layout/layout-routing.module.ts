import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { DashBoardComponent } from './Pages/dash-board/dash-board.component';
import { UserComponent } from './Pages/user/user.component';
import { ClientComponent } from './Pages/client/client.component';
import { EmailComponent } from './Pages/email/email.component';
import { EmailLogComponent } from './Pages/email-log/email-log.component';
import { ReportComponent } from './Pages/report/report.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'dashboard', component: DashBoardComponent },
      { path: 'users', component: UserComponent },
      { path: 'clients', component: ClientComponent },
      { path: 'emails', component: EmailComponent },
      { path: 'logEmails', component: EmailLogComponent },
      { path: 'reports', component: ReportComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LayoutRoutingModule {}
