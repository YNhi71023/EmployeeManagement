import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { an } from '@fullcalendar/core/internal-common';
import { MenuItem } from 'primeng/api';
import { EmployeeService } from 'src/app/page/service/employee.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.scss'
})
export class ManagerComponent {
  constructor(
    private employeeService: EmployeeService,
    private router: Router,
  ){}
  items: MenuItem[] =  [
    { label: 'Home' }, 
    { label: 'Employee Manager' }, 
  ]
  home: MenuItem | undefined;
  employee_id:any
  manager_id:any
  employee_name:any=''
  manager_name:any=''
  visible_model_create: boolean = false;
  ngOnInit(): void {
    this.filter();
  }
  showDialog() {
    this.visible_model_create = true;
  }
  dataManager:any = []
  filter(){
    this.dataManager=[]
    this.employeeService.FilterManager(0,0,this.employee_name,this.manager_name).subscribe((data:any)=>{
      console.log(data)
      if(data.status == "ok"){
        this.dataManager = data.data
        console.log(this.dataManager)
      }
      else{
        alert(data.message)
      }
    })
  }
}
