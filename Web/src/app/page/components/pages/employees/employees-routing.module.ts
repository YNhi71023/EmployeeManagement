import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EmployeeComponent } from './employees.component';
import { authGuard } from 'src/app/page/service/auth.guard';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: EmployeeComponent , canActivate: [authGuard],}
    ])],
    exports: [RouterModule]
})
export class EmployeesRoutingModule { }
