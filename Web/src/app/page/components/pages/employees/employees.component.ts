import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { getDateMeta, NowTimer } from '@fullcalendar/core/internal';
import { em } from '@fullcalendar/core/internal-common';
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
    ) { }
    items: MenuItem[] = [{ label: 'Home' }, { label: 'Employees' }];
    ngOnInit(): void {
        this.loadPosition();
        this.loadType();
        this.loadEmployee();
        this.filter();
    }
    home: MenuItem | undefined;
    value2: string | undefined;
    visible_model_createUser: boolean = false;
    visible_model_create: boolean = false;
    listEmployee: any = [];
    listemployeeType: any = [];
    listemployeePosition: any = [];
    selectedMan: any;
    selectedempPosition: any;
    selectedempType: any;
    loading: boolean = false;
    employee_id: any = ''
    employee_name: any = '';
    sex: any = '';
    card_number: any = '';
    employee_type_id: any = '';
    mail: any = '';
    mobile: any = '';
    position_id: any = '';
    manager_id: any = ';'
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
    cr_username: any = '';
    cr_password: any = '';
    old_password: any = '';
    new_password: any = '';
    item_edit: any = undefined;
    item_manager: any = undefined;
    visible_model_edit: boolean = false;
    visible_model_changepass: boolean = false;
    fileTemplete!: File;
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
                this.item_edit.image_profile = response.url;
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
    showCreUser() {
        this.visible_model_createUser = true;
    }
    showChangePass() {
        this.visible_model_changepass = true;
    }
    showDialog() {
        this.visible_model_create = true;
    }
    loadEmployee() {
        this.employeeService.FilterEmployee(0, '', -1, '', 2052, '', '', 0, 0).subscribe((data: any) => {
            if (data.status == 'ok') {
                this.listEmployee = data.data.map((obj) => ({
                    ...obj,
                    employee_label: obj.employee_id + ' - ' + obj.employee_name,
                }));

            }
        });
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
            manager_id: this.selectedMan == undefined ? 0 : this.selectedMan.employee_id
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
                param.position_id,
                param.manager_id
            )
            .subscribe((data: any) => {
                console.log(data);
                this.loading = false;
                if (data.status == 'ok') {
                    this.dataEmp = data.data;
                    console.log(this.dataEmp);
                }
            });
    }
    dataManager: any = []

    employee_user: any = ''
    convertSex(x: string): number {
        if (x == 'Nữ') {
            return 1;
        } else if (x == 'Nam') {
            return 0;
        } else {
            return -1;
        }
    }
    showError: boolean = false;
    create() {
        const sexValue = this.convertSex(this.cr_sex);
        if (!this.cr_employee_name || !sexValue || !this.cr_card_number || !this.cr_image_before_card || !this.cr_image_after_card || !this.cr_birthday || !this.cr_address || !this.cr_mail || !this.cr_mobile || !this.cr_image_profile || !this.cr_employee_type_id || !this.cr_position_id) {
            this.showError = true;
            return;
        }
        this.showError = false;
        console.log('Data is valid, submitting...');
        this.employeeService.CreateEmployee(this.cr_employee_name, sexValue, this.cr_card_number, this.cr_image_before_card, this.cr_image_after_card, this.cr_birthday, this.cr_address, this.cr_mail, this.cr_mobile, this.cr_image_profile, this.cr_employee_type_id, this.cr_position_id)
            .subscribe((data: any) => {
                console.log(data);
                this.employee_user = data.employee_id;
                this.visible_model_create = false
                this.filter()
            });
    }
    resetForm() {
        const sexValue = this.convertSex(this.cr_sex);
        this.cr_employee_name = '',
            this.cr_sex = '',
            this.cr_card_number = '',
            this.cr_image_before_card = null,
            this.cr_image_after_card = null,
            this.cr_birthday = '',
            this.cr_address = '',
            this.cr_mail = '',
            this.cr_mobile = '',
            this.cr_image_profile = null,
            this.cr_employee_type_id = null,
            this.cr_position_id = null
    }
    createUser() {
        if (this.item_edit.user_name == '') {
            alert("enter user name")
            return
        }
        if (this.item_edit.password == '') {
            alert("enter password")
            return
        }
        console.log(this.item_edit.employee_id)
        console.log(this.item_edit.user_name)
        console.log(this.item_edit.password)
        this.employeeService.CreateUser(this.item_edit.employee_id, this.cr_username, this.cr_password).subscribe((data: any) => {
            console.log(data)
            this.visible_model_createUser = false
        })
    }
    changePass() {
        this.employeeService.ChangePassword(this.item_edit.employee_id, this.old_password, this.new_password).subscribe((data: any) => {
            if(data.status == "ok"){
                alert(data.message)
                this.visible_model_changepass = false
            }else{
                alert(data.message)
                this.old_password=''
                this.new_password=''
            }
        })
    }
    createManager() {
        console.log(this.item_edit.employee_id)
        console.log(this.item_edit.manager_id)
        this.employeeService.CreateManager(this.item_edit.employee_id, this.item_edit.manager_id).subscribe((data: any) => {
            console.log(data)
            alert("Create manager successfull")
            this.filter()
        })
    }
    save() {
        const sexValue = this.convertSex(this.item_edit.sex);
        // console.log(sexValue)
        // console.log(this.item_edit.image_profile)
        // console.log(this.item_edit)
        this.employeeService.UpdateEmployee(this.item_edit.employee_id, this.item_edit.employee_name, sexValue, this.item_edit.card_number, this.item_edit.image_before_card, this.item_edit.image_after_card, this.item_edit.birthday, this.item_edit.address, this.item_edit.mail, this.item_edit.mobile, this.item_edit.image_profile, this.item_edit.employee_type_id, this.item_edit.position_id).subscribe((data: any) => {
            console.log(data)
            this.visible_model_edit = false;
            this.filter()
        })
    }
    visible_model_createPosition: boolean = false
    showcreatePositiom() {
        this.visible_model_createPosition = true;
    }
    cr_position_code: any = ''
    cr_position_name: any = ''
    createPosition() {
        if (this.cr_position_code == '') {
            alert("enter position code")
            return
        }
        if (this.cr_position_name == '') {
            alert("enter position name")
            return
        }
        if (this.cr_position_code.length < 2) {
            alert("add position code")
            return
        }
        if (this.cr_position_name.length < 5) {
            alert("add position name")
            return
        }
        this.employeeService.CreatePosition(this.cr_position_code, this.cr_position_name).subscribe((data: any) => {
            console.log(data)
            if (data.status == "ok") {
                if (data.message == "successfull.") {
                    this.visible_model_createPosition = false
                    alert("Create successfull")
                    this.loadPosition()
                } else {
                    alert(data.message)
                    this.cr_position_code = ''
                    this.cr_position_name = ''

                }
            } else {
                alert(data.message)
            }
            this.cr_position_code = ''
            this.cr_position_name = ''
        })
    }
    updateManager() {
        this.employeeService.UpdateManager(this.item_edit.employee_id, this.item_edit.manager_id).subscribe((data: any) => {
            console.log(data)
            alert("Update manager successfull")
            this.filter()
        })
    }
}
