import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { EmployeeService } from 'src/app/page/service/employee.service';

@Component({
  selector: 'app-types',
  templateUrl: './types.component.html',
  styleUrl: './types.component.scss'
})
export class TypesComponent {
  constructor(private employeeService: EmployeeService,private router: Router) {}
  items: MenuItem[] =  [
    { label: 'Home' }, 
    { label: 'Employee Type' }, 
    
  ]
  home: MenuItem | undefined;

  selectedempPosition: any
  selectedempType: any
  employee_type_code: any = ''
  employee_type_name:any = ''
  loading: boolean = false;
  visible_model_cretate: boolean = false;
  visible_model_edit:boolean = false;
  cr_type_code: any = ''
  cr_type_name: any = ''
  cr_level:any = ''
  showDialog() {
    this.visible_model_cretate = true;
  }
  item_edit:any
  Show(item:any){
    console.log(item)
    this.item_edit = item
    this.visible_model_edit = true;
  }

  dataEmployeeType: any = []
  filter(){
    this.loading = true
    console.log(this.employee_type_code)
    console.log(this.employee_type_name)
    this.dataEmployeeType = []
    this.employeeService.FilterType(0,this.employee_type_code,this.employee_type_name,0).subscribe((data:any)=>{
      console.log(data)
      this.loading = false
      if(data.status == "ok"){
        this.dataEmployeeType = data.data
        console.log(this.dataEmployeeType)
      }
      else{
        alert(data.message)
      }
    })
  }
  create(){
    // if(this.cr_type_code == ''){
    //   alert("enter type code")
    //   return 
    // }
    // if(this.cr_type_name == ''){
    //   alert("enter type name")
    //   return
    // }
    // if(this.cr_level < 0){
    //   alert("enter type level")
    //   return
    // }
    // if(this.cr_type_code.length < 2){
    //   alert("add type code")
    //   return
    // }
    // if(this.cr_type_name.length < 5){
    //   alert("add type name")
    //   return
    // }
    this.employeeService.CreateType(this.cr_type_code,this.cr_type_name, this.cr_level).subscribe((data:any)=>{
      console.log(data)
      if(data.status == "ok"){
        if(data.message == "successfull."){
          this.visible_model_cretate=false
          alert("Create successfull")
        }else{
          alert(data.message)
          this.cr_type_code = ''
          this.cr_type_name = '' 
          this.cr_level =  ''       
        }       
      }else{
        alert(data.message)
      }
      this.cr_type_code = ''
      this.cr_type_name = ''
      this.cr_level = ''
      this.filter()
    })
  }
  save(){
    console.log(this.item_edit)
      if(this.item_edit.employee_type_code == ''){
        alert("enter type name")
        return
      }
      if(this.item_edit.employee_type_name.length < 5){
        alert("add type name")
        return
      }     
    this.employeeService.UpdateType(this.item_edit.employee_type_code,this.item_edit.employee_type_name,this.item_edit.level,this.item_edit.employee_type_id).subscribe((data:any)=>{
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
}
