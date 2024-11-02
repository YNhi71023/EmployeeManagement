import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
  })


  export class LoginService {

    constructor(private http:HttpClient){}
    
    onLogin(username: string, password: string){
      return this.http.post(environment.domain + 'Users/LoginUser',
        {
          username,password
        }
      );
  
    }
  }
  