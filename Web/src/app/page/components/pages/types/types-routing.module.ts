import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TypesComponent } from './types.component';
import { authGuard } from 'src/app/page/service/auth.guard';


@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: TypesComponent, canActivate: [authGuard] }
  ])],
    exports: [RouterModule]
  })
export class TypesRoutingModule { }
