import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/page/service/auth.guard';
import { ManagerComponent } from './manager.component';


@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: ManagerComponent, canActivate: [authGuard] }
  ])],
    exports: [RouterModule]
  })
export class ManagerRoutingModule { }
