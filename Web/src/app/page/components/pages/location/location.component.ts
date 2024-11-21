import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { StoreService } from 'src/app/page/service/store.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrl: './location.component.scss'
})
export class LocationComponent {
  constructor(private storeService: StoreService,private router: Router) {}
  items: MenuItem[] =  [
    { label: 'Home' }, 
    { label: 'Location' },   
  ]
  home: MenuItem | undefined;
  ngOnInit(): void {
    this.filter()
  }
  location_code:any = ''
  location_name: any = ''
  location_address: any = ''
  ward_code: any = ''
  district_code: any = ''
  province_code: any = ''
  location_type_id: any = ''
  dataLocation:any = []
  visible_model_create: boolean = false;
  filter(){
    this.storeService.FilterLocation(this.location_code,this.location_name,this.location_address,this.ward_code,this.district_code,this.province_code,0).subscribe((data:any)=>{
      console.log(data)
      if(data.status == "ok"){
        this.dataLocation = data.data
        console.log(this.dataLocation)
      }
      else{
        alert(data.message)
      }
    })
  }
}
