import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { APIsService } from 'src/app/API/apis.service';
import * as Aos from 'aos';
@Component({
  selector: 'app-fund-transfer',
  templateUrl: './fund-transfer.component.html',
  styleUrls: ['./fund-transfer.component.css']
})
export class FundTransferComponent implements OnInit {

  constructor(private fb: FormBuilder, private Loginapi: APIsService,private router:Router) { }

  ngOnInit(): void {
    Aos.init();
   
  }
  formModel = new FormGroup({

    accountId: new FormControl('', [Validators.required]),
    balance: new FormControl('', [Validators.required]),
    description:new FormControl('', [Validators.required])
  });

  SaveData() {
 
    this.Loginapi.LoginPost(this.formModel.value).subscribe(
    
    );
  }
  reloadCurrentPage() {
    window.location.reload();
   }

}
