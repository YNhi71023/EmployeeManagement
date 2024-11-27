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
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import { InputMaskModule } from 'primeng/inputmask';
import { ImageModule } from 'primeng/image';
import { FileUpload, FileUploadModule } from 'primeng/fileupload';
import { CardModule } from 'primeng/card';

@NgModule({
  imports: [
    CommonModule,
    LocationRoutingModule,
    BreadcrumbModule,
    FormsModule,
    ToolbarModule,
    ButtonModule,
    TableModule,
    InputTextModule,
    DropdownModule,
    DialogModule,
    InputMaskModule,
    ImageModule, 
    FileUploadModule,
    CardModule

  ],declarations: [LocationComponent],
})
export class LocationModule { }