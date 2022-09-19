import { Component, OnInit } from '@angular/core';
import { APIsService } from 'src/app/API/apis.service';
import { ISupport } from 'src/app/Interface/ISupport';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FAQComponent implements OnInit {
  public FAQ : ISupport[]=[];
  constructor(private api:APIsService) { }

  ngOnInit(): void {
    this.api.getFaqData().subscribe((data:ISupport[]) =>{
      this.FAQ=data;
      console.log(this.FAQ);
    })
         
  }

}
