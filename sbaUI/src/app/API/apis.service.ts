//BHANU -- 17/09/2022 -- WEB API CONNECTIVITY
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRegister } from '../Interface/IRegister';
import { ISupport } from '../Interface/ISupport';
import { HttpHeaders } from '@angular/common/http';
import { IUserDetail } from '../Interface/IUserDetail';
@Injectable({
  providedIn: 'root'
})
export class APIsService {
  url = "https://localhost:44329/api/"
  constructor(private http: HttpClient) { }
//GETTERS
  //BHANU -- 17/09/2022 -- GETTING DATA FROM DATABASE BY CONNECTING TO GET CONTOLLER IN WEB API{
  getRegisterData(): Observable<IRegister[]> {
    return this.http.get<IRegister[]>(this.url + '/');
  }

  //BHANU -- 19/09/2022 -- GETTING DATA FROM SUPPORT DATABASE
getFaqData():Observable<ISupport[]>{
  return this.http.get<ISupport[]>(this.url+'supports');
}

getUserLoggedData():Observable<IUserDetail[]>{
 
  return this.http.get<IUserDetail[]>(this.url+'UserDetails');
}

//}

  //BHANU -- 17/09/2022 -- POSTING DATA FROM DATABASE BY CONNECTING TO REGISTER CONTOLLER IN WEB API{
  RegisterPost(object: any) {
    return this.http.post(this.url + 'UserProfile/Register', object, {
      headers: {
        "Access-Control-Allow-Origin": "*"
      }
    })
  }

  //Akshay -- 19/09/2022 -- POSTING DATA FROM DATABASE BY CONNECTING TO Login CONTOLLER IN WEB API
  LoginPost(data: any) {
    return this.http.post(this.url + 'UserProfile/Login', data, {
      headers: {
        "Access-Control-Allow-Origin": "*"
      }
    })
  }

//}




  //Akshay -- 20/09/2022 -- POSTING DATA FROM DATABASE BY CONNECTING TO Feedback CONTOLLER IN WEB API
  FeedbackPost(data: any) {
    return this.http.post(this.url + 'Feedbacks/fdback', data, {
      headers: {
        "Access-Control-Allow-Origin": "*"
      }
    })
  }



 
}
