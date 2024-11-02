import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PositionRoutingModule } from './position-routing.module';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { PositionComponent } from './position.component';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { BadgeModule } from 'primeng/badge';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  
  imports: [
    CommonModule,
    PositionRoutingModule,
    BreadcrumbModule,
    InputTextModule,
    FormsModule,
    ToolbarModule,
    ButtonModule,
    TableModule,
    DialogModule,
    DropdownModule
    
  ],declarations: [PositionComponent],
})
export class PositionModule { }
