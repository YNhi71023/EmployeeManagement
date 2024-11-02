import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TypesRoutingModule } from './types-routing.module';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';
import { TypesComponent } from './types.component';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  imports: [
    CommonModule,
    TypesRoutingModule, 
    BreadcrumbModule,
    ButtonModule,
    FormsModule,
    TableModule,
    ToolbarModule,
    FormsModule,   
    DialogModule,
    InputTextModule,  
    DropdownModule
  ],declarations: [TypesComponent],
})
export class TypesModule { }
