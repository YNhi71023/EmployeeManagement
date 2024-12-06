import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { StoreService } from 'src/app/page/service/store.service';
import { UploadService } from 'src/app/page/service/UploadService';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrl: './location.component.scss'
})
export class LocationComponent {
  constructor(private storeService: StoreService, private router: Router, private uploadService: UploadService) { }
  items: MenuItem[] = [
    { label: 'Home' },
    { label: 'Location' },
  ]
  home: MenuItem | undefined;
  ngOnInit(): void {
    this.filter();
    this.loadProvinces()
    this.loadLocationType()
  }

  location_code: any = ''
  location_name: any = ''
  location_address: any = ''
  ward_code: any = ''
  district_code: any = ''
  province_code: any = ''
  image_overview: any = ''
  lat: any = ''
  lng: any = ''
  location_type_id: any = ''
  location_type_code: any = ''
  location_type_name: any = ''
  cr_location_code: any = ''
  cr_location_name: any = ''
  cr_location_address: any = ''
  cr_ward_code: any = ''
  cr_district_code: any = ''
  cr_province_code: any = ''
  cr_location_type_id: any = ''
  cr_lat: any = ''
  cr_lng: any = ''
  cr_image_overview: any = ''
  selectedWard: any
  selectedDistrict: any
  selectedProvince: any
  selectedLocationType: any
  listWard: any = []
  listDistrict: any = []
  listProvince: any = []
  listLocationType: any = []
  dataLocation: any = []
  item_edit: any = undefined;
  visible_model_create: boolean = false;
  visible_model_edit: boolean = false;
  showError: boolean = false;
  fileTemplete!: File;
  showDialog_Create() {
    this.visible_model_create = true;
  } 
  ShowDialog_Update(item: any) {
    console.log(item);
    this.item_edit = item;
    this.visible_model_edit = true;
  }
  loadProvinces(): void {
    this.storeService.FilterProvince('', '').subscribe((data: any) => {
      if (data.status == 'ok') {
        this.listProvince = data.data.map((obj: any) => ({
          province_code: obj.province_code,
          province_label: obj.province_name,
        }));
      }
    });
  }
  onProvinceChange(provinceCode: string | null) {
    if (!provinceCode) {
      this.selectedDistrict = null;
      this.selectedWard = null;
      this.listDistrict = [];
      this.listWard = [];
      return;
    }
    this.storeService.FilterDistrict(provinceCode).subscribe((data: any) => {
      if (data.status == "ok") {
        this.listDistrict = data.data.map((obj: any) => ({
          district_code: obj.district_code,
          district_label: obj.district_name,
        }));
      }
    });
  }
  onDistrictChange(districtCode: string | null) {
    if (!districtCode) {
      this.selectedWard = null;
      this.listWard = [];
      return;
    }

    this.storeService.FilterWard(districtCode).subscribe((data: any) => {
      if (data.status == "ok") {
        this.listWard = data.data.map((obj: any) => ({
          ward_code: obj.ward_code,
          ward_label: obj.ward_name,
        }));
      }
    });
  }
  loadLocationType() {
    this.storeService.FilterLocationType('', '').subscribe((data: any) => {
      if (data.status == 'ok') {
        this.listLocationType = data.data.map((obj) => ({
          ...obj,
          locationtype_label: obj.location_type_code + ' - ' + obj.location_type_name,
        }));

      }
    })
  }
  onChangeFile(event: any, img: string) {
    this.fileTemplete = event.target.files[0];
    this.saveFile(img);
  }
  saveFile(img: string) {
    const formDataUpload = new FormData();
    formDataUpload.append('files', this.fileTemplete);
    this.uploadService.uploadImage(this.fileTemplete).subscribe(
      (response) => {
        console.log(response);
        this[img] = response.url;
        this.item_edit.image_overview = response.url;
      },
      (error) => {
        console.error('File upload failed', error);
      }
    );
  }
  filter() {
    this.dataLocation = []
    const param = {
      province_code: this.selectedProvince == undefined ? '' : this.selectedProvince.province_code,
      district_code: this.selectedDistrict == undefined ? '' : this.selectedDistrict.district_code,
      ward_code: this.selectedWard == undefined ? '' : this.selectedWard.ward_code,
      location_type_id: this.selectedLocationType == undefined ? 0 : this.selectedLocationType.location_type_id,
    }
    this.storeService.FilterLocation(
      0,
      this.location_code,
      this.location_name,
      this.location_address,
      param.ward_code,
      param.district_code,
      param.province_code,
      param.location_type_id, -1,1
    ).subscribe((data: any) => {
      console.log(data);
      if (data.status == "ok") {
        this.dataLocation = data.data;
        console.log(this.dataLocation);
        
      } else {
        alert(data.message);
      }
    });
  }
  resetForm() {
      this.cr_location_code = '',
      this.cr_location_name = '',
      this.cr_location_address = '',
      this.cr_ward_code = '',
      this.cr_district_code = '',
      this.cr_province_code = '',
      this.cr_location_type_id = '',
      this.cr_lat = '',
      this.cr_lng = '',
      this.cr_image_overview = ''
  }
  create() {
    const param = {
      cr_province_code: this.selectedProvince == undefined ? '' : this.selectedProvince.province_code,
      cr_district_code: this.selectedDistrict == undefined ? '' : this.selectedDistrict.district_code,
      cr_ward_code: this.selectedWard == undefined ? '' : this.selectedWard.ward_code,
    }
    this.storeService.CreateLocation(
      this.cr_location_code,
      this.cr_location_name,
      this.cr_location_address,
      param.cr_ward_code,
      param.cr_district_code,
      param.cr_province_code,
      this.cr_location_type_id,
      this.cr_lat,
      this.cr_lng,
      this.cr_image_overview).subscribe((data: any) => {
        if (data.status == "ok") {
          if (data.message == "successfull.") {
            this.visible_model_create = false
            alert("Create successfull")
          } else {
            alert(data.message)
          }
        } else {
          alert(data.message)
        }
        
        this.filter()
      })
  }
  save() {
    const param = {
      province_code: this.selectedProvince?.province_code || '',
      district_code: this.selectedDistrict?.district_code || '',
      ward_code: this.selectedWard?.ward_code || ''
    }
    this.storeService
      .UpdateLocation(
        this.item_edit.location_id,
        this.item_edit.location_code,
        this.item_edit.location_name,
        this.item_edit.location_address,
        param.ward_code,
        param.district_code,
        param.province_code,
        this.item_edit.location_type_id,
        this.item_edit.lat,
        this.item_edit.lng,
        this.item_edit.image_overview
      ).subscribe(
        (data: any) => {
          console.log('API Response:', data);
          this.visible_model_edit=false
          this.filter()
        });
  }

  visible_model_createLocationtype: boolean = false
  showCreateLocationType() {
    this.visible_model_createLocationtype = true;
  }
  cr_location_type_code:any
  cr_location_type_name:any
  createLocationType() {
    this.storeService.CreateLocationType(this.cr_location_type_code, this.cr_location_type_name).subscribe((data: any) => {
      console.log(data)
      if (data.status == "ok") {
        if (data.message == "successfull.") {
          this.visible_model_createLocationtype = false
          alert("Create successfull")
          this.loadLocationType()
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
    })
  }
}
