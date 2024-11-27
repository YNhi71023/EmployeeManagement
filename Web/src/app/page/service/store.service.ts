import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})
export class StoreService{
    constructor(private http:HttpClient){}
        
    controller: string = 'Store/'
    FilterProvince(province_code:string,province_name:string){
        return this.http.post(environment.domain + this.controller + 'FilterProvince',{province_code,province_name})
    }
    FilterDistrict(province_code:string){
        return this.http.post(environment.domain + this.controller + 'FilterDistrict',{province_code})
    }
    FilterWard(district_code:string){
        return this.http.post(environment.domain + this.controller + 'FilterWard',{district_code})
    }
    FilterLocation(location_id:number,location_code: string,location_name: string,location_address:string,ward_code:string,district_code:string,province_code:string,location_type_id:number){
        return this.http.post(environment.domain + this.controller + 'FilterLocation', {location_id,location_code,location_name,location_address,ward_code,district_code,province_code,location_type_id})
    }
    FilterLocationType(location_type_code: string,location_type_name: string){
        return this.http.post(environment.domain + this.controller + 'FilterLocationType', {location_type_code,location_type_name})
    }
    CreateLocationType(location_type_code: string,location_type_name: string){
        return this.http.post(environment.domain + this.controller + 'CreateLocationType', {location_type_code,location_type_name})
    }
    CreateLocation(location_code:string,location_name:string,location_address:string,ward_code:string,district_code:string,province_code:string,location_type_id:number,lat:number,lng:number,image_overview:string){
        return this.http.post(environment.domain + this.controller + 'CreateLocation', {location_code,location_name,location_address,ward_code,district_code,province_code,location_type_id,lat,lng,image_overview })
    }
    UpdateLocationType(location_type_code: string,location_type_name: string,location_type_id: number){
        return this.http.post(environment.domain + this.controller + 'UpdateLocationType',{location_type_code,location_type_name,location_type_id})
    }
    UpdateLocation(location_id:number,location_code:string,location_name:string,location_address:string,ward_code:string,district_code:string,province_code:string,location_type_id:number,lat:number,lng:number,image_overview:string){
        return this.http.post(environment.domain + this.controller +'UpdateLocation', {location_id,location_code,location_name,location_address,ward_code,district_code,province_code,location_type_id,lat,lng,image_overview})
    }
}