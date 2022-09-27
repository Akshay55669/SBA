import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl,FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { APIsService } from 'src/app/API/apis.service';
import { IUserDetail } from 'src/app/Interface/IUserDetail';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private user:APIsService, private route:Router,private fb:FormBuilder) { }
  User!:any;

   formModel = new FormGroup({

    Name: new FormControl('', [Validators.required]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Opinions: new FormControl('', [Validators.required]),
    
  });

  ngOnInit(): void {
this.user.getUserLoggedData().subscribe((data:IUserDetail[]) =>{
  this.User=data;
  console.log(this.User);
})
 

  }


  onSubmit(){
    
  }
}
