import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/page/service/auth.guard';
import { LocationManagerComponent } from './locationmanager.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: LocationManagerComponent, canActivate: [authGuard] }
  ])],
    exports: [RouterModule]
  })
export class LocationManagerRoutingModule { }
