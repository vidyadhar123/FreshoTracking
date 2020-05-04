import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { GridLayoutComponent } from './gridLayout.component';
import {gridLayoutRoutingModule} from './gridLayout.routing.module';
import { DemoMaterialModule } from '../material.module';

@NgModule({
    declarations: [
        GridLayoutComponent
    ],
    imports: [
        gridLayoutRoutingModule,
        DemoMaterialModule
    ],
    exports: [GridLayoutComponent]
})
export class gridLayoutModule { }