import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/page/service/auth.guard';
import { LocationComponent } from './location.component';

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: LocationComponent, canActivate: [authGuard] }
  ])],
    exports: [RouterModule]
  })
export class LocationRoutingModule { }
