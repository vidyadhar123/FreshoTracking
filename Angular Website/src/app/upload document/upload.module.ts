import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { UploadDocumentComponent } from './upload-document.component';
import { UploadDocumentRoutingModule } from './upload-routing.module';
import { DemoMaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';


@NgModule({
    declarations: [
        UploadDocumentComponent
    ],
    imports: [
        UploadDocumentRoutingModule,
        DemoMaterialModule,
        CommonModule
    ],
    exports: [UploadDocumentComponent]
})
export class UploadModule { }
