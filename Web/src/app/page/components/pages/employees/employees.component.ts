import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { getDateMeta, NowTimer } from '@fullcalendar/core/internal';
import { MenuItem, MessageService } from 'primeng/api';
import { FileUploadModule, UploadEvent } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { EmployeeService } from 'src/app/page/service/employee.service';
import { UploadService } from 'src/app/page/service/UploadService';

@Component({
    selector: 'app-employees',
    templateUrl: './employees.component.html',
    styleUrl: './employees.component.scss',
})
export class EmployeeComponent {
    constructor(
        private employeeService: EmployeeService,
      private router: Router,
      private uploadService: UploadService
    ) {}
    items: MenuItem[] = [{ label: 'Home' }, { label: 'Employees' }];
    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.
        this.loadPosition();
        this.loadType();
        this.filter();
    }
    home: MenuItem | undefined;
    value2: string | undefined;
    visible_model_createUser: boolean = false;
    visible_model_create: boolean = false;
    listemployeeType: any = [];
    listemployeePosition: any = [];
    selectedempPosition: any;
    selectedempType: any;
    loading: boolean = false;
    employee_name: any = '';
    sex: any = '';
    card_number: any = '';
    employee_type_id: any = '';
    mail: any = '';
    mobile: any = '';
    position_id: any = '';
    checked: boolean = false;
    date: Date | undefined;
    image_before_card: any = '';
    image_after_card: any = '';
    birthday: any = '';
    address: any = '';
    image_profile: any = '';
    dataEmp: any = [];
    cr_employee_name: any = '';
    cr_sex: any = '';
    cr_card_number: any = '';
    cr_image_before_card: any = '';
    cr_image_after_card: any = '';
    cr_birthday: any = '';
    cr_address: any = '';
    cr_mail: any = '';
    cr_mobile: any = '';
    cr_image_profile: any = '';
    cr_employee_type_id: any = '';
    cr_position_id: any = '';
    item_edit: any = undefined;
    visible_model_edit: boolean = false;
    fileTemplete!: File;
    onChangeFile(event: any) {
        this.fileTemplete = event.target.files[0];
        this.saveFile()
    }
    saveFile() {
        const formDataUpload = new FormData();
        formDataUpload.append('files', this.fileTemplete);
        this.uploadService.uploadImage(this.fileTemplete).subscribe(
            (response) => {
              console.log(response);
               this.item_edit.image_profile = response.url
            },
            (error) => {
              console.error('File upload failed', error);
            }
          );
    }
    onChangeFileimgprofile(event: any) {
        this.fileTemplete = event.target.files[0];
        this.saveFileimgprofile()
    }
    saveFileimgprofile() {
        const formDataUpload = new FormData();
        formDataUpload.append('files', this.fileTemplete);
        this.uploadService.uploadImage(this.fileTemplete).subscribe(
            (response) => {
              console.log(response);
               this.cr_image_profile = response.url
            },
            (error) => {
              console.error('File upload failed', error);
            }
          );
    }
    onChangeFileimgbefore(event: any) {
        this.fileTemplete = event.target.files[0];
        this.saveFileimgbefore()
    }
    saveFileimgbefore() {
        const formDataUpload = new FormData();
        formDataUpload.append('files', this.fileTemplete);
        this.uploadService.uploadImage(this.fileTemplete).subscribe(
            (response) => {
              console.log(response);
               this.cr_image_before_card = response.url
            },
            (error) => {
              console.error('File upload failed', error);
            }
          );
    }
    onChangeFileimgafter(event: any) {
        this.fileTemplete = event.target.files[0];
        this.saveFileimgafter()
    }
    saveFileimgafter() {
        const formDataUpload = new FormData();
        formDataUpload.append('files', this.fileTemplete);
        this.uploadService.uploadImage(this.fileTemplete).subscribe(
            (response) => {
              console.log(response);
               this.cr_image_after_card = response.url
            },
            (error) => {
              console.error('File upload failed', error);
            }
          );
    }    
    Show(item: any) {
        console.log(item);
        this.item_edit = item;
        this.visible_model_edit = true;
    }
    showCreUser(){
      this.visible_model_createUser = true;
    }
    showDialog() {      
      this.visible_model_create = true;
    }
    loadPosition() {
        this.employeeService
            .FilterPosition(0, '', '')
            .subscribe((data: any) => {
                console.log(data);
                if (data.status == 'ok') {
                    this.listemployeePosition = data.data.map((obj) => ({
                        ...obj,
                        position_label:
                            obj.position_code + ' - ' + obj.position_name,
                    }));
                }
            });
    }
    loadType() {
        this.employeeService.FilterType(0, '', '', 0).subscribe((data: any) => {
            console.log(data);
            if (data.status == 'ok') {
                this.listemployeeType = data.data.map((obj) => ({
                    ...obj,
                    type_label:
                        obj.employee_type_code + ' - ' + obj.employee_type_name,
                }));
            }
        });
    }
    filter() {
        this.dataEmp = [];
        const param = {
            type_id:
                this.selectedempType == undefined
                    ? 0
                    : this.selectedempType.employee_type_id,
            position_id:
                this.selectedempPosition == undefined
                    ? 0
                    : this.selectedempPosition.position_id,
        };
        this.employeeService
            .FilterEmployee(
                0,
                this.employee_name,
                -1,
                this.card_number,
                param.type_id,
                this.mail,
                this.mobile,
                param.position_id
            )
            .subscribe((data: any) => {
                console.log(data);
                this.loading = false;
                if (data.status == 'ok') {
                    this.dataEmp = data.data;
                    console.log(this.dataEmp);
                } else {
                }
            });
    }
    
    employee_user: any = ''
    create() {
        this.employeeService.CreateEmployee(this.cr_employee_name,this.cr_sex,this.cr_card_number,this.cr_image_before_card,this.cr_image_after_card,this.cr_birthday,this.cr_address,this.cr_mail,this.cr_mobile,this.cr_image_profile,this.cr_employee_type_id,this.cr_position_id)
            .subscribe((data: any) => {
                console.log(data);
                this.employee_user = data.employee_id;
            });
    }
    createUser(){
        if(this.item_edit.user_name==''){
            alert("enter user name")
            return
        }
        if(this.item_edit.password==''){
            alert("enter password")
            return
        }
      console.log(this.item_edit.employee_id)
      console.log(this.item_edit.user_name)
      console.log(this.item_edit.password)
      this.employeeService.CreateUser(this.item_edit.employee_id, this.item_edit.user_name,this.item_edit.password).subscribe((data:any)=>{
        console.log(data)
      })
    }
    save(){
        console.log(this.item_edit)
        this.employeeService.UpdateEmployee(this.item_edit.employee_id,this.item_edit.employee_name,this.item_edit.sex,this.item_edit.card_number,this.item_edit.image_before_card,this.item_edit.image_after_card,this.item_edit.birthday,this.item_edit.address,this.item_edit.mail,this.item_edit.mobile,this.item_edit.image_profile,this.item_edit.employee_type_id,this.item_edit.position_id).subscribe((data:any)=>{
            console.log(data)
            this.visible_model_edit = false;
            this.filter()
        })
    }
}
