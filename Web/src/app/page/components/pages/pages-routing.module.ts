import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'crud', loadChildren: () => import('./crud/crud.module').then(m => m.CrudModule) },
        { path: 'type', loadChildren: () => import('./types/types.module').then(m => m.TypesModule) },
        { path: 'employee', loadChildren: () => import('./employees/employees.module').then(m => m.EmployeesModule) },
        { path: 'position', loadChildren: () => import('./position/position.module').then(m => m.PositionModule) },
        { path: 'location-type', loadChildren: () => import('./location-type/location-type.module').then(m => m.LocationTypeModule) },
        { path: 'location', loadChildren: () => import('./location/location.module').then(m => m.LocationModule) },  
        { path: 'locationmanager', loadChildren: () => import('./locationmanager/locationmanager.module').then(m => m.LocationManagerModule) },  
        { path: '**', redirectTo: '/notfound' }
    ])],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
