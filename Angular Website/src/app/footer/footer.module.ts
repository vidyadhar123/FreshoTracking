import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FooterComponent } from './footer.component';
import { FooterRoutingModule } from './footer-routing.module';

@NgModule({
    declarations: [
        FooterComponent
    ],
    imports: [
        BrowserModule,
        FooterRoutingModule
    ],
    exports: [FooterComponent]
})
export class FooterModule { }
