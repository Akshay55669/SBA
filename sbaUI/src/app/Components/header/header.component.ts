import { Component, OnInit } from '@angular/core';
import { Router, withDebugTracing } from '@angular/router';
import { APIsService } from 'src/app/API/apis.service';
import { IUserDetail } from 'src/app/Interface/IUserDetail';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
loggedIn:boolean=false;
  constructor(private user:APIsService, private route:Router) { }
  User!:any;
  ngOnInit(): void {
this.user.getUserLoggedData().subscribe((data:IUserDetail[]) =>{
  this.User=data;
  console.log(this.User);
})

  }

  Logout(User:IUserDetail){
    if (localStorage.getItem('token') != null) {
    localStorage.removeItem('token');
    this.route.navigate(['/login'])
    User.login=false;
    window.location.reload();
    }
  }
//temp logut
LogoutUser(){
  if (localStorage.getItem('token') != null) {
  localStorage.removeItem('token');
  this.route.navigate(['/login'])
 window.location.reload();
  }
}

}
