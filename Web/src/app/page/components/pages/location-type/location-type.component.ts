import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { StoreService } from 'src/app/page/service/store.service';

@Component({
  selector: 'app-location-type',
  templateUrl: './location-type.component.html',
  styleUrl: './location-type.component.scss'
})
export class LocationTypeComponent {
  constructor(private storeService: StoreService, private router: Router) { }
  items: MenuItem[] = [
    { label: 'Home' },
    { label: 'Location Type' },

  ]
  home: MenuItem | undefined;

  ngOnInit(): void {
    this.filter()
  }
  loading: boolean = false;
  location_type_code: any = ''
  location_type_name: any = ''
  cr_location_type_code: any = ''
  cr_location_type_name: any = ''
  dataLocationType: any = []
  visible_model_create: boolean = false;
  visible_model_edit:boolean = false;
  showCreateLocationType() {
    this.visible_model_create = true;
  }
  item_edit:any
  Show(item:any){
    console.log(item)
    this.item_edit = item
    this.visible_model_edit = true;
  }
  resetForm(){
    this.cr_location_type_code=''
    this.cr_location_type_name=''
  }
  filter() {
    this.storeService.FilterLocationType(this.location_type_code, this.location_type_name).subscribe((data: any) => {
      console.log(data)
      this.loading = false
      if (data.status == "ok") {
        this.dataLocationType = data.data
        console.log(this.dataLocationType)
      }
      else {
        alert(data.message)
      }
    })
  }
  create() {
    this.storeService.CreateLocationType(this.cr_location_type_code, this.cr_location_type_name).subscribe((data: any) => {
      console.log(data)
      if (data.status == "ok") {
        if (data.message == "successfull.") {
          this.visible_model_create = false
          alert("Create successfull")
        } else {
          alert(data.message)
          this.cr_location_type_code = ''
          this.cr_location_type_name = ''
        }
      } else {
        alert(data.message)
      }
      this.cr_location_type_code = ''
      this.cr_location_type_name = ''
      this.filter()
    })
  }
  
  save(){
    this.storeService.UpdateLocationType(this.item_edit.location_type_code,this.item_edit.location_type_name,this.item_edit.location_type_id).subscribe((data:any)=>{
      console.log(data)
    })
  }
}
