import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { APIsService } from 'src/app/API/apis.service';
import { IRegister } from 'src/app/Interface/IRegister';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private fb: FormBuilder, private Registerapi: APIsService) {}

  ngOnInit(): void {}
  firstName:FormControl = new FormControl("");

  lastName:FormControl = new FormControl("");

  UserName:FormControl = new FormControl("");

  Email:FormControl = new FormControl("");

  PhoneNumber:FormControl = new FormControl("");

  dob:FormControl = new FormControl("");

  panCard:FormControl = new FormControl("");

  Password:FormControl = new FormControl("");


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
  // onSubmit() {
  //   this.Registerapi.RegisterPost(object:IRegister).subscribe(
  //     (res: any) => {
  //       if (res.succeeded) {
  //         this.formModel.reset();
  //         //this.toastr.success('New user created!', 'Registration successful.');
  //       } else {
  //         res.errors.forEach(element => {
  //           switch (element.code) {
  //             case 'DuplicateUserName':
  //               //this.toastr.error('Username is already taken','Registration failed.');
  //               break;

  //             default:
  //             //this.toastr.error(element.description,'Registration failed.');
  //               break;
  //           }
  //         });
  //       }
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   );
  // }

  save(){

    let Registration:IRegister = {

      firstName:this.firstName.value,

      lastName:this.lastName.value,

      UserName:this.UserName.value,

      Email:this.Email.value,

      PhoneNumber:this.PhoneNumber.value,

      dob:this.dob.value,

      panCard:this.panCard.value,

      Password:this.Password.value,

    };

    this.Registerapi.RegisterPost(Registration);

  }
}
