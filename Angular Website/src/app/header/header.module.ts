import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';
import { HeaderRoutingModule } from './header-routing.module';

@NgModule({
    declarations: [
        HeaderComponent
    ],
    imports: [
        BrowserModule,
        HeaderRoutingModule
    ],
    exports: [HeaderComponent]
})
export class HeaderModule { }
