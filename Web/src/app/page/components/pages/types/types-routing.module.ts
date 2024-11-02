import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TypesComponent } from './types.component';


@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: TypesComponent }
  ])],
    exports: [RouterModule]
  })
export class TypesRoutingModule { }
