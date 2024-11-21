import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { en } from "@fullcalendar/core/internal-common";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})
export class StoreService{
    constructor(private http:HttpClient){}
        
    controller: string = 'Store/'
    FilterLocation(location_code: string,location_name: string,location_address:string,ward_code:string,district_code:string,province_code:string,location_type_id:number){
        return this.http.post(environment.domain + this.controller + 'FilterLocation', {location_code,location_name,location_address,ward_code,district_code,province_code,location_type_id})
    }
    FilterLocationType(location_type_code: string,location_type_name: string){
        return this.http.post(environment.domain + this.controller + 'FilterLocationType', {location_type_code,location_type_name})
    }
    CreateLocationType(location_type_code: string,location_type_name: string){
        return this.http.post(environment.domain + this.controller + 'CreateLocationType', {location_type_code,location_type_name})
    }
    UpdateLocationType(location_type_id: number,location_type_code: string,location_type_name: string){
        return this.http.post(environment.domain + this.controller + 'UpdateLocationType',{location_type_id,location_type_code,location_type_name})
    }
}
