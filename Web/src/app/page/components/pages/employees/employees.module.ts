import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeesComponent } from './employees.component';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        EmployeesRoutingModule,
        ButtonModule,
        DropdownModule,
        FormsModule
    ],
    declarations: [EmployeesComponent]
})
export class EmployeesModule { }
