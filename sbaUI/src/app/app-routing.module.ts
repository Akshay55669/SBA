import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './Components/admin/admin.component';
import { AuthGuard } from './auth/auth.guard';
import { FAQComponent } from './Components/faq/faq.component';
import { ForbiddenComponent } from './Components/forbidden/forbidden.component';
import { FeedbackComponent } from './Components/feedback/feedback.component';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { MainComponent } from './Components/main/main.component';
import { FundTransferComponent } from './Components/fund-transfer/fund-transfer.component';
import { AboutusComponent } from './Components/aboutus/aboutus.component';

const routes: Routes = [
  //BHANU -- 17/09/22 -- Adding paths
  {path:'',component:HomeComponent},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'faq',component:FAQComponent},
  {path:'forbidden',component:ForbiddenComponent},
  {path:'Admin',component:AdminComponent,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}},
  {path:'main',component:MainComponent,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}},
  {path:'feedback',component:FeedbackComponent,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}},
  {path:'moneytransfer',component:FundTransferComponent,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}},
  {path:'aboutus',component:AboutusComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
