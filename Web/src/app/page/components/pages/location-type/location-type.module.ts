import { NgModule } from '@angular/core';
import { LocationTypeComponent } from './location-type.component';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { CommonModule } from '@angular/common';
import { LocationTypeRoutingModule } from './location-type-routing.module';
import { ToolbarModule } from 'primeng/toolbar';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';

@NgModule({
  imports: [
    CommonModule,
    BreadcrumbModule,
    LocationTypeRoutingModule,
    ToolbarModule,
    FormsModule,
    InputTextModule,
    ButtonModule,
    TableModule,
    DialogModule
  ],declarations: [LocationTypeComponent],
})
export class LocationTypeModule { }
