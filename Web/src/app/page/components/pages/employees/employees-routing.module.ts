import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EmployeeComponent } from './employees.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: EmployeeComponent }
    ])],
    exports: [RouterModule]
})
export class EmployeesRoutingModule { }
