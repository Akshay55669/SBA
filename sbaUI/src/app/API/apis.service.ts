//BHANU -- 17/09/2022 -- WEB API CONNECTIVITY
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRegister } from '../Interface/IRegister';
@Injectable({
  providedIn: 'root'
})
export class APIsService {
  url="https://localhost:44329/api/"
  constructor(private http:HttpClient) { }

  //BHANU -- 17/09/2022 -- GETTING DATA FROM DATABASE BY CONNECTING TO GET CONTOLLER IN WEB API
  getRegisterData():Observable<IRegister[]>{
    return this.http.get<IRegister[]>(this.url+'/');
  }

  //BHANU -- 17/09/2022 -- POSTING DATA FROM DATABASE BY CONNECTING TO REGISTER CONTOLLER IN WEB API
  RegisterPost(object:IRegister){
this.http.post<IRegister>(this.url+ 'UserProfile/Register',object, {
  headers:{
    "Access-Control-Allow-Origin":"*"
  }
}).subscribe(result => console.log("User details entered in Database Successfully !"));// subscribing
}
}
