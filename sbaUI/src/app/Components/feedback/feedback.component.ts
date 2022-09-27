import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import * as Aos from 'aos';
import { APIsService } from 'src/app/API/apis.service';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  constructor(private fb: FormBuilder, private feedbackapi: APIsService) { }

  ngOnInit(): void {
    Aos.init();
    this.formModel.reset();
   
  }
  formModel = new FormGroup({

    Name: new FormControl('', [Validators.required]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Opinions: new FormControl('', [Validators.required]),
    
  });

  SaveData() {
  debugger
    this.feedbackapi.FeedbackPost(this.formModel.value).subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.formModel.reset();
          window.location.reload();
          console.log('Feedback Submitted sucessfully');
        }
        else {
          console.log("error occured");
        }
      }
    );
  }
}
