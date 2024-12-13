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
  constructor(private employeeService: EmployeeService, private router: Router) { }
  items: MenuItem[] = [
    { label: 'Home' },
    { label: 'Employee Type' },

  ]
  home: MenuItem | undefined;

  selectedempPosition: any
  selectedempType: any
  employee_type_code: any = ''
  employee_type_name: any = ''
  loading: boolean = false;
  visible_model_create: boolean = false;
  visible_model_edit: boolean = false;
  cr_type_code: any = ''
  cr_type_name: any = ''
  cr_level: number = 0
  showDialog() {
    this.visible_model_create = true;
  }
  item_edit: any
  Show(item: any) {
    console.log(item)
    this.item_edit = item
    this.visible_model_edit = true;
  }
  ngOnInit(): void {
    this.filter()
  }
  dataEmployeeType: any = []
  filter() {
    this.loading = true
    console.log(this.employee_type_name)
    this.dataEmployeeType = []
    this.employeeService.FilterType(0, this.employee_type_code, this.employee_type_name, 0).subscribe((data: any) => {
      console.log(data)
      this.loading = false
      if (data.status == "ok") {
        this.dataEmployeeType = data.data
        console.log(this.dataEmployeeType)
      }
      else {
        alert(data.message)
      }
    })
  }
  resetForm() {
    this.cr_type_code = ''
    this.cr_type_name = ''
    this.cr_level = 0
  }
  create() {
    const validations = [
      { condition: this.cr_type_code === '' || this.cr_type_code.length < 3, message: "Type code cannot be empty and must be at least 3 characters long." },
      { condition: this.cr_type_name === '' || this.cr_type_name.length < 5, message: "Type name cannot be empty and must be at least 5 characters long." },
      { condition: this.cr_level === 0, message: "Type level cannot be zero. Please enter a valid level." }
    ];

    for (const validation of validations) {
      if (validation.condition) {
        alert(validation.message);
        return;
      }
    }

    this.employeeService.CreateType(this.cr_type_code, this.cr_type_name, this.cr_level).subscribe((data: any) => {
      console.log(data)
      if (data.status == "ok") {
        if (data.message == "successfull.") {
          this.visible_model_create = false
          alert("Create successfull")
        } else {
          alert(data.message)
          this.cr_type_code = ''
          this.cr_type_name = ''
          this.cr_level = 0
        }
      } else {
        alert(data.message)
      }
      this.cr_type_code = ''
      this.cr_type_name = ''
      this.cr_level = 0
      this.filter()
    })
  }
  save() {
    console.log(this.item_edit)
    if (this.item_edit.employee_type_name === '' || this.item_edit.employee_type_name.length < 5) {
      alert("Type name cannot be empty and must be at least 5 characters long.");
      return;
    }
    this.employeeService.UpdateType(this.item_edit.employee_type_code, this.item_edit.employee_type_name, this.item_edit.level, this.item_edit.employee_type_id).subscribe((data: any) => {
      console.log(data)
      if (data.status == "ok") {
        alert(data.message)
        this.visible_model_edit = false;
      } else {
        alert(data.message)
      }
      this.filter
    })
  }
}
