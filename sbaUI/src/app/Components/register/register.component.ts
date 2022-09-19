import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { APIsService } from 'src/app/API/apis.service';
import { IRegister } from 'src/app/Interface/IRegister';
import * as Aos from 'aos';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private fb: FormBuilder, private Registerapi: APIsService) { }
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

    Password: new FormControl('', [Validators.required])
    // ConfirmPassword:new FormControl('',[ Validators.required])
  });

  SaveData() {
    // debugger
    this.Registerapi.RegisterPost(this.formModel.value).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.formModel.reset();
          console.log('New user created!', 'Registration successful.');
        }
        else {
          console.log("error occured");
        }
      }
    );
  }
  // firstName:FormControl = new FormControl("");

  // lastName:FormControl = new FormControl("");

  // UserName:FormControl = new FormControl("");

  // Email:FormControl = new FormControl("");

  // PhoneNumber:FormControl = new FormControl("");

  // dob:FormControl = new FormControl("");

  // panCard:FormControl = new FormControl("");

  // Password:FormControl = new FormControl("");


  // //comparing passwords
  // comparePasswords(fb: FormGroup) {
  //   let confirmPswrdCtrl = fb.get('ConfirmPassword');
  //   //passwordMismatch
  //   //confirmPswrdCtrl.errors={passwordMismatch:true}
  //   if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
  //     if (fb.get('Password').value != confirmPswrdCtrl.value)
  //       confirmPswrdCtrl.setErrors({ passwordMismatch: true });
  //     else
  //       confirmPswrdCtrl.setErrors(null);
  //   }
  // }
  // onSubmit():void{
  //   this.Registerapi.RegisterPost(this.userProfile).subscribe(
  //   (res: any) => {
  //     if (res.succeeded) {
  //       this.formModel.reset();
  //       //this.toastr.success('New user created!', 'Registration successful.');
  //     } else {
  //       res.errors.forEach(element => {
  //         switch (element.code) {
  //           case 'DuplicateUserName':
  //             //this.toastr.error('Username is already taken','Registration failed.');
  //             break;

  //           default:
  //           //this.toastr.error(element.description,'Registration failed.');
  //             break;
  //         }
  //       });
  //     }
  //   },
  //   err => {
  //     console.log(err);
  //   }
  // );
  // }

  // save(){

  //   let Registration:IRegister = {

  //     firstName:this.firstName.value,

  //     lastName:this.lastName.value,

  //     UserName:this.UserName.value,

  //     Email:this.Email.value,

  //     PhoneNumber:this.PhoneNumber.value,

  //     dob:this.dob.value,

  //     panCard:this.panCard.value,

  //     Password:this.Password.value,

  //   };

  //   this.Registerapi.RegisterPost(Registration);

  // }



}
