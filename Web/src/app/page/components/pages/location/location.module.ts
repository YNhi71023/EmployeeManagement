import { NgModule } from '@angular/core';
import { LocationComponent } from './location.component';
import { CommonModule } from '@angular/common';
import { LocationRoutingModule } from './location-routing.module';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { FormsModule } from '@angular/forms';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  imports: [
    CommonModule,
    LocationRoutingModule,
    BreadcrumbModule,
    FormsModule,
    ToolbarModule,
    ButtonModule,
    TableModule,
    InputTextModule

  ],declarations: [LocationComponent],
})
export class LocationModule { }