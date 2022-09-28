import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { APIsService } from 'src/app/API/apis.service';
import * as Aos from 'aos';
import { IUserDetail } from 'src/app/Interface/IUserDetail';
import { IAccDetail } from 'src/app/Interface/IAccDetail';
@Component({
  selector: 'app-fund-transfer',
  templateUrl: './fund-transfer.component.html',
  styleUrls: ['./fund-transfer.component.css']
})
export class FundTransferComponent implements OnInit {

  constructor(private fb: FormBuilder, private api: APIsService,private router:Router) { }
  User!:any;
 Account:any;
  ngOnInit(): void {
    Aos.init();
    this.api.getUserLoggedData().subscribe((data:IUserDetail[]) =>{
      this.User=data;
      console.log(this.User);
    });
    
    this.api.getUserAccData().subscribe((data1:IAccDetail[]) =>{
      this.Account=data1;
      console.log(this.Account);
    });
  }
  formModel = new FormGroup({

    accountId: new FormControl('', [Validators.required]),
    balance: new FormControl(0, [Validators.required]),
    description:new FormControl('', [Validators.required])
    
  });

  SaveData() {
   
     var money = this.formModel.value.balance;
    if(money!=this.Account.balance){
      this.api.MoneyPost(this.formModel.value).subscribe(
        (res: any) => {
          if (res.succeeded) {
            this.formModel.reset();
            window.location.reload();
            console.log('money tranfered sucessfully');
          }
          else {
            console.log("error occured");
            this.formModel.reset();
          }
        }
      );
    }
 
  }
  reloadCurrentPage() {
    window.location.reload();
   }

}
