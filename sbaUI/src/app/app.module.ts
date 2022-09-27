import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { HomeComponent } from './Components/home/home.component';
import { HeaderComponent } from './Components/header/header.component';
import { APIsService } from './API/apis.service';
import { AdminComponent } from './Components/admin/admin.component';
import { FAQComponent } from './Components/faq/faq.component';
import { ForbiddenComponent } from './Components/forbidden/forbidden.component';
import { Authinterceptor } from './auth/auth.interceptor';
import { MainComponent } from './Components/main/main.component';
import { AccountDetailsComponent } from './Components/account-details/account-details.component';
import { FeedbackComponent } from './Components/feedback/feedback.component';
import { FooterComponent } from './Components/footer/footer.component';
import { StatementComponent } from './Components/statement/statement.component';
import { FundTransferComponent } from './Components/fund-transfer/fund-transfer.component';
import { AboutusComponent } from './Components/aboutus/aboutus.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    HomeComponent,
    HeaderComponent,
    AdminComponent,
    FAQComponent,
    ForbiddenComponent,
    MainComponent,
    AccountDetailsComponent,
    FeedbackComponent,
    FooterComponent,
    StatementComponent,
    FundTransferComponent,
    AboutusComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [APIsService,{
    provide: HTTP_INTERCEPTORS,
    useClass: Authinterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
