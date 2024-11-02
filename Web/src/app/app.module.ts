import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './page/components/notfound/notfound.component';
import { ProductService } from './page/service/product.service';
import { CountryService } from './page/service/country.service';
import { CustomerService } from './page/service/customer.service';
import { EventService } from './page/service/event.service';
import { IconService } from './page/service/icon.service';
import { NodeService } from './page/service/node.service';
import { PhotoService } from './page/service/photo.service';
import { customInterceptor } from './interceptor/custom.interceptor';
import { provideHttpClient, withInterceptors } from '@angular/common/http';


@NgModule({
    declarations: [AppComponent, NotfoundComponent],
    imports: [AppRoutingModule, AppLayoutModule],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        CountryService, CustomerService, EventService, IconService, NodeService,
        PhotoService, ProductService,
        provideHttpClient(withInterceptors([customInterceptor]))
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
