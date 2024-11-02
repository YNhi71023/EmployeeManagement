import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing.module';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule } from '@angular/forms';

import { TableModule } from 'primeng/table';import { EmployeeComponent } from './employees.component';

import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ToolbarModule } from 'primeng/toolbar';
import { FormLayoutDemoRoutingModule } from '../../uikit/formlayout/formlayoutdemo-routing.module';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { InputMaskModule } from 'primeng/inputmask';
import { DialogModule } from 'primeng/dialog';
import { ImageModule } from 'primeng/image';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { CalendarModule } from 'primeng/calendar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { FileUploadModule } from 'primeng/fileupload';
import { CardModule } from 'primeng/card';

@NgModule({
    imports: [
        CardModule,
        CommonModule,
        EmployeesRoutingModule,
        ButtonModule,
        DropdownModule,
        FormsModule,
        TableModule,
        BreadcrumbModule,
        ToolbarModule,
        CommonModule,
		FormsModule,
		FormLayoutDemoRoutingModule,
		AutoCompleteModule,
		DropdownModule,
		InputMaskModule,
        DialogModule,
        ImageModule,
        PasswordModule,
        InputTextModule,
        CheckboxModule,
        CalendarModule, 
        RadioButtonModule,
        FileUploadModule
    ],
    declarations: [EmployeeComponent]
})
export class EmployeesModule { }


