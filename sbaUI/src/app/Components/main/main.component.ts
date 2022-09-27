import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { APIsService } from 'src/app/API/apis.service';
import { IAccDetail } from 'src/app/Interface/IAccDetail';
import { IUserDetail } from 'src/app/Interface/IUserDetail';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private user:APIsService, private route:Router) { }
  User!:any;
 Account:any;

  ngOnInit(): void {
this.user.getUserLoggedData().subscribe((data:IUserDetail[]) =>{
  this.User=data;
  console.log(this.User);
});

this.user.getUserAccData().subscribe((data1:IAccDetail[]) =>{
  this.Account=data1;
  console.log(this.Account);
});

  }
}
