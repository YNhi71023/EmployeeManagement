import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'crud', loadChildren: () => import('./crud/crud.module').then(m => m.CrudModule) },
        { path: 'type', loadChildren: () => import('./types/types.module').then(m => m.TypesModule) },
        { path: 'employee', loadChildren: () => import('./employees/employees.module').then(m => m.EmployeesModule) },
        { path: 'position', loadChildren: () => import('./position/position.module').then(m => m.PositionModule) },
        { path: 'manager', loadChildren: () => import('./manager/manager.module').then(m => m.ManagerModule) },  
        { path: '**', redirectTo: '/notfound' }
    ])],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
