import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as Aos from 'aos';
// import { ToastrService } from 'ngx-toastr';
import { APIsService } from 'src/app/API/apis.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // constructor(private fb: FormBuilder, private Loginapi: APIsService,private router:Router, private toastr:ToastrService) { }
  constructor(private fb: FormBuilder, private Loginapi: APIsService,private router:Router) { }

  ngOnInit(): void {
    Aos.init();
    if(localStorage.getItem('token')!=null){
      this.router.navigateByUrl('/home');
    }
  }
  formModel = new FormGroup({

    UserName: new FormControl('', [Validators.required]),
    Password: new FormControl('', [Validators.required])
  });

  SaveData() {
    // debugger
    this.Loginapi.LoginPost(this.formModel.value).subscribe(
      (res: any) => {

        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('');

        if (res.succeeded) {
          this.formModel.reset();
          console.log('Login successful.');
        }
        else {
          console.log("error occured");
        }
      }
      // err=>{
      //   if(err.status==400)
      //   this.toastr.error('Incorrect UserName or Password.','Authentication failed');
      //   else
      //   console.log(err);
      // }
    );
  }

}
