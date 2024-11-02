import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { LoginComponent } from './page/components/auth/login/login.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'

})
export class AppComponent{

    constructor(private primengConfig: PrimeNGConfig) { }

    ngOnInit() {
        this.primengConfig.ripple = true;
    }
}
