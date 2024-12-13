import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { EmployeeService } from 'src/app/page/service/employee.service';

@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrl: './position.component.scss'
})
export class PositionComponent {
  constructor(private employeeService: EmployeeService,private router: Router) {}
  items: MenuItem[] =  [
    { label: 'Home' }, 
    { label: 'Employee Position' },    
  ]
  home: MenuItem | undefined;
  loading: boolean = false
  listemployeeType: any = [{"employee_type_id":2,"employee_type_code":"Admin","employee_type_name":"Quản lý hệ thống","level":2},{"employee_type_id":3,"employee_type_code":"Manager","employee_type_name":"Quản lý","level":3},{"employee_type_id":4,"employee_type_code":"Employee","employee_type_name":"Nhân viên","level":4}]
  listemployeePosition: any = [{"position_id":1,"position_code":"Sale","position_name":"Nhân viên bán hàng","employee_type_id":4},{"position_id":2,"position_code":"SaleManager","position_name":"Quản lý nhân viên Sale","employee_type_id":3},{"position_id":3,"position_code":"Audit","position_name":"Nhân viên kiểm tra","employee_type_id":4},{"position_id":4,"position_code":"AuditSup","position_name":"Quản lý nhân viên Audit","employee_type_id":3},{"position_id":5,"position_code":"Marketing","position_name":"Nhân viên quản bá sản phẩm","employee_type_id":4},{"position_id":6,"position_code":"MarManager","position_name":"Quản lý nhân viên Marketing","employee_type_id":3},{"position_id":7,"position_code":"Security","position_name":"Nhân viên bảo vệ","employee_type_id":4},{"position_id":8,"position_code":"SecurityManager","position_name":"Quản lý nhân viên bảo vệ","employee_type_id":4}]
  selectedempPosition: any
  selectedempType: any
  employee_position_code: any = ''
  employee_position_name: any = ''
  visible_model_create: boolean = false;
  visible_model_edit:boolean = false;
  visible_model_delete:boolean = false;
  cr_position_code: any = ''
  cr_position_name: any = ''
  checked:boolean=false;
  showDialog() {
      this.visible_model_create = true;
  }
  item_edit:any
  Show(item:any){
    console.log(item)
    this.item_edit = item
    this.visible_model_edit = true;
  }
  item_delete:any
  Show_delete(item:any){
    console.log(item)
    this.item_delete = item
    this.visible_model_delete = true;
  }
  ngOnInit(): void {
    this.filter()
  }
  
  save(){
    console.log(this.item_edit)
    if (this.item_edit.position_name === '' || this.item_edit.position_name.length < 5) {
      alert("Position name cannot be empty and must be at least 5 characters long.");
      return;
    }
    
    this.employeeService.UpdatePosition(this.item_edit.position_code, this.item_edit.position_name, this.item_edit.position_id).subscribe((data:any)=>{
      console.log(data)
      if(data.status == "ok"){
        alert(data.message)
        this.visible_model_edit = false;
      }else{
        alert(data.message)
      }
      this.filter
    })
  }
  delete(){  
      this.employeeService.DeletePosition(this.item_delete.position_id).subscribe((data:any)=>{
        if(data.status == "ok"){
          alert(data.message)
          this.visible_model_delete = false;
        }else{
          alert(data.message)
        }
        this.filter()
      })
  }
  

  dataEmpPosition: any = []
  filter(){
    this.loading = true
    console.log(this.employee_position_code)
    console.log(this.employee_position_name)
    this.dataEmpPosition = []
    this.employeeService.FilterPosition(0,this.employee_position_code,this.employee_position_name).subscribe((data:any)=>{
      console.log(data)
      this.loading = false
      if(data.status == "ok"){
        this.dataEmpPosition = data.data
        console.log(this.dataEmpPosition)
      }else{
        alert(data.message)
      }
    })
  }
  resetForm(){
    this.cr_position_code=''
    this.cr_position_name=''
  }
  create(){
    const validations = [
      { condition: this.cr_position_code === '' || this.cr_position_code.length < 3, message: "Position code cannot be empty and must be at least 3 characters long." },
      { condition: this.cr_position_name === ''|| this.cr_position_name.length < 5 , message: "Position name cannot be empty and must be at least 5 characters long." },
    ];

    for (const validation of validations) {
      if (validation.condition) {
        alert(validation.message);
        return;
      }
    }
    this.employeeService.CreatePosition(this.cr_position_code,this.cr_position_name).subscribe((data:any)=>{
      console.log(data)
      if(data.status == "ok"){
        if(data.message == "successfull."){
          this.visible_model_create=false
          alert("Create successfull")
        }else{
          alert(data.message)
          this.cr_position_code = ''
          this.cr_position_name = ''         
        }       
      }else{
        alert(data.message)
      }
      this.cr_position_code = ''
      this.cr_position_name = ''
      this.filter()
    })
  }

}
