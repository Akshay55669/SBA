import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { APIsService } from 'src/app/API/apis.service';
import { IRegister } from 'src/app/Interface/IRegister';
import * as Aos from 'aos';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private fb: FormBuilder, private Registerapi: APIsService,private route:Router) { }
  userProfile!: IRegister;
  myForm!: FormGroup;

  ngOnInit(): void {
    Aos.init();
    this.formModel.reset();
  }
  formModel = new FormGroup({

    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    UserName: new FormControl('', [Validators.required]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    PhoneNumber: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
    dob: new FormControl('', [Validators.required]),
    panCard: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z]{5}[0-9]{4}[A-Za-z]$')]),
    Password: new FormControl('', [Validators.required]),
   
    // ConfirmPassword:new FormControl('',[ Validators.required])
  });

  SaveData() {
    // debugger
   
    this.Registerapi.RegisterPost(this.formModel.value).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.route.navigateByUrl('/login');
          console.log('New user created!', 'Registration successful.');
        }
        else {
          console.log("error occured");
          
        }
      }
    );
  }




}
