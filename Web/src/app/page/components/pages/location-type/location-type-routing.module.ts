import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/page/service/auth.guard';
import { LocationTypeComponent } from './location-type.component';


@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: LocationTypeComponent, canActivate: [authGuard] }
  ])],
    exports: [RouterModule]
  })
export class LocationTypeRoutingModule { }
