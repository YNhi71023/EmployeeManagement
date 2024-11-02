import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
  })


export class EmployeeService {
    constructor(private http:HttpClient){}    

      controller: string = 'Employees/'
      controller1: string = 'Users/'
      FilterEmployee(employee_id:number,employee_name:string,sex:number,card_number:string,employee_type_id:number,mail:string,mobile:string,position_id:number){
        return this.http.post(environment.domain + this.controller+ 'FilterEmployee',{employee_id,employee_name,sex,card_number,employee_type_id,mail,mobile,position_id});
      }
      
      FilterType(type_id:number,type_code:string, type_name:string, level: number ){
        return this.http.post(environment.domain + this.controller+ 'FilterType',{type_id,type_code,type_name,level});
      }
      FilterPosition(position_id:number,position_code:string,position_name:string){
        return this.http.post(environment.domain + this.controller+ 'FilterPosition',{position_id,position_code,position_name});
      }
      CreateUser(employee_id:number,user_name:string,password:string){
        return this.http.post(environment.domain+this.controller1+ 'CreateUser',{employee_id,user_name,password})
      }
      CreateEmployee(employee_name:string, sex:number,card_number: string,image_before_card:string,image_after_card:string,birthday:Date, address:string,mail: string,mobile: string,image_profile: string,employee_type_id: number,position_id: number){
        return this.http.post(environment.domain + this.controller+ 'CreateEmployee',{employee_name,sex,card_number,image_before_card,image_after_card,birthday,address,mail,mobile,image_profile,employee_type_id,position_id});
      }
      CreatePosition(position_code:string,position_name:string){
        return this.http.post(environment.domain + this.controller+ 'CreatePosition',{position_code,position_name})
      }

      CreateType(type_code: string, type_name:string, level: number){
        return this.http.post(environment.domain + this.controller + 'CreateType', {type_code,type_name,level})
      }
      UpdateEmployee(employee_id: number,employee_name: string,sex: number,card_number: string,image_before_card: string,image_after_card:string,birthday: Date,address: string,mail: string,mobile: string,image_profile: string,employee_type_id: number,position_id: number){
        return this.http.post(environment.domain + this.controller + 'UpdateEmployee', {
          employee_id,employee_name,sex,card_number,image_before_card,image_after_card,birthday,address,mail,mobile,image_profile,employee_type_id,position_id})
      }
      UpdatePosition(position_code:string,position_name:string,position_id:number){
        return this.http.post(environment.domain + this.controller + 'UpdatePosition', {position_code,position_name,position_id})
      }

      UpdateType(type_code:string,type_name:string,level:number,type_id:number){
        return this.http.post(environment.domain + this.controller + 'UpdateType', {type_code,type_name,level,type_id})
      }

      DeletePosition(position_id:number){
        return this.http.post(environment.domain + this.controller + 'DeletePosition', {position_id})
      }
      
}
