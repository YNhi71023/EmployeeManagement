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
import { Tag } from 'primeng/tag';
import { Rating } from 'primeng/rating';
import { SelectButton } from 'primeng/selectbutton';
import { TableModule } from 'primeng/table';

@NgModule({
  imports: [
    LocationManagerRoutingModule,
    PickListModule,
    CommonModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    CardModule,
    ToolbarModule,
    TableModule
  ],declarations: [LocationManagerComponent],
})
export class LocationManagerModule { }