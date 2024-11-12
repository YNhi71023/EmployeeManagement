import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { authGuard } from '../../service/auth.guard';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: DashboardComponent, 
            canActivate: [authGuard], }
    ])],
    exports: [RouterModule]
})
export class DashboardsRoutingModule { }

// import { NgModule } from '@angular/core';
// import { RouterModule, Routes } from '@angular/router';
// import { DashboardComponent } from './dashboard.component';

// const routes: Routes = [
//     {
//         path: '',
//         component: DashboardComponent
//     }
// ];

// @NgModule({
//     imports: [RouterModule.forChild(routes)],
//     exports: [RouterModule]
// })
// export class DashboardRoutingModule {}
