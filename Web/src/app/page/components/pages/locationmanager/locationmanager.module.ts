import { NgModule } from '@angular/core';
import { LocationManagerComponent } from './locationmanager.component';
import { LocationManagerRoutingModule } from './locationmanager-routing.module';
import { PickListModule } from 'primeng/picklist';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { CardModule } from 'primeng/card';
import { ToolbarModule } from 'primeng/toolbar';

@NgModule({
  imports: [
    LocationManagerRoutingModule,
    PickListModule,
    CommonModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    CardModule,
    ToolbarModule
  ],declarations: [LocationManagerComponent],
})
export class LocationManagerModule { }