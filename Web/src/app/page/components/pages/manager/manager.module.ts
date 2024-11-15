import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ManagerRoutingModule } from './manager-routing.module';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { ManagerComponent } from './manager.component';

@NgModule({
  imports: [
    CommonModule,
    ManagerRoutingModule, 
    BreadcrumbModule,
    ButtonModule,
    FormsModule,
    TableModule,
    ToolbarModule,
    FormsModule,   
    DialogModule,
    InputTextModule,  
    DropdownModule
  ],declarations: [ManagerComponent],
})
export class ManagerModule { }
