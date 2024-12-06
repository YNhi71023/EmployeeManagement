import { Component, ChangeDetectorRef } from '@angular/core';
import { dA } from '@fullcalendar/core/internal-common';
import { EmployeeService } from 'src/app/page/service/employee.service';
import { StoreService } from 'src/app/page/service/store.service';

@Component({
  selector: 'app-locationmanager',
  templateUrl: './locationmanager.component.html',
  styleUrls: ['./locationmanager.component.scss']
})
export class LocationManagerComponent {
  sourceLocation: any[] = []; 
  targetLocation: any[] = []; 
  location_id: any = '';
  location_code: string = '';
  location_name: string = '';
  location_address: string = '';
  ward_code: string = '';
  district_code: string = '';
  province_code: string = '';
  image_overview: string = '';
  lat: string = '';
  lng: string = '';
  location_type_id: any = '';
  location_type_code: string = '';
  location_type_name: string = '';
  employee_id: any = ''
  employee_name: any = ''
  listMan: any = [];
  listWard: any = [];
  listDistrict: any = [];
  listProvince: any = [];
  listLocationType: any = [];

  selectedMan: any;
  selectedWard: any;
  selectedDistrict: any;
  selectedProvince: any;
  selectedLocationType: any;

  constructor(
    private storeService: StoreService,
    private cdr: ChangeDetectorRef,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    this.loadProvinces();
    this.loadLocationType();
    this.loadManager();
    this.filter();
    if (!Array.isArray(this.sourceLocation)) {
      this.sourceLocation = [];
    }
  }
  loadManager() {
    this.employeeService.FilterEmployee(0, '', -1, '', 2055, '', '', 0,0).subscribe((data: any) => {
      console.log(data)  
      if (data.status == 'ok') {
            this.listMan = data.data.map((obj) => ({                 
                ...obj,
                employee_label: obj.employee_id + ' - ' + obj.employee_name,
            }));
            
        }
    });
}
  loadProvinces() {
    this.storeService.FilterProvince('', '').subscribe((data: any) => {
      if (data.status == 'ok') {
        this.listProvince = data.data.map((obj: any) => ({
          province_code: obj.province_code,
          province_label: obj.province_name,
        }));
      }
    });
  }

  loadLocationType() {
    this.storeService.FilterLocationType('', '').subscribe((data: any) => {
      if (data.status == 'ok') {
        this.listLocationType = data.data.map((obj: any) => ({
          ...obj,
          locationtype_label: obj.location_type_code + ' - ' + obj.location_type_name,
        }));
      }
    });
  }

  filter() {
    const param = {
      province_code: this.selectedProvince ? this.selectedProvince.province_code : '',
      district_code: this.selectedDistrict ? this.selectedDistrict.district_code : '',
      ward_code: this.selectedWard ? this.selectedWard.ward_code : '',
      location_type_id: this.selectedLocationType ? this.selectedLocationType.location_type_id : 0,
      employee_id:this.selectedMan==undefined ? 0 : this.selectedMan.employee_id
    };

    this.storeService.FilterLocation(0,this.location_code,this.location_name,this.location_address,param.ward_code,param.district_code,param.province_code,param.location_type_id,-1,-1).subscribe((response: any) => {
      if (response && response.data && Array.isArray(response.data)) {
        this.sourceLocation = response.data;
      } else {
        console.error('Dữ liệu không hợp lệ hoặc không chứa mảng');
        this.sourceLocation = [];
      }
      this.cdr.markForCheck();
    });
  }
  onMoveToTarget(event: any): void {
    const movedLocations = event.items; 
    if (!this.selectedMan) {
      alert('Vui lòng chọn nhân viên trước.');
      this.targetLocation = this.targetLocation.filter((item) => !movedLocations.includes(item));
      return;
    }
  
    movedLocations.forEach((location: any) => {
      const location_id = location.location_id;
      const employee_id = this.selectedMan.employee_id;
  
      this.storeService.CreateLocationManager(location_id, employee_id)
        .subscribe(
          (response: any) => {
            if (response.status === 'ok') {
              console.log('Tạo thành công:', response.message);
            } else {
              console.error('Lỗi khi tạo quản lý:', response.message);
            }
          },
          (error) => {
            console.error('Lỗi API:', error);
          }
        );
    });
    this.cdr.markForCheck(); 
  }
  onMoveToSource(event: any): void {
    const movedLocations = event.items; // Các mục đã di chuyển
    movedLocations.forEach((location: any) => {
      const location_id = location.location_id;
  
      this.storeService
        .DeleteLocationManager(location_id) // Gọi API xóa Manager Location
        .subscribe(
          (response: any) => {
            if (response.status === 'ok') {
              console.log('Đã hoàn tác thành công:', response.message);
            } else {
              console.error('Lỗi khi hoàn tác:', response.message);
            }
            this.cdr.markForCheck(); // Cập nhật giao diện
          },
          (error) => {
            console.error('Lỗi API:', error);
          }
        );
    });
  }
  
  
  filterLocationManager(){
    const param = {
      employee_id:this.selectedMan==undefined ? 0 : this.selectedMan.employee_id
    };
    this.storeService.FilterLocationManager(param.employee_id).subscribe((response:any)=>{
      console.log(response)
      if (response && response.data && Array.isArray(response.data)) {
        this.targetLocation = response.data;
      } else {
        console.error('Dữ liệu không hợp lệ hoặc không chứa mảng');
        this.targetLocation = [];
      }
      this.cdr.markForCheck();
    })
  }
}
