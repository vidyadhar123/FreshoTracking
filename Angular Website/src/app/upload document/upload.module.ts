import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { UploadDocumentComponent } from './upload-document.component';
import { UploadDocumentRoutingModule } from './upload-routing.module';



@NgModule({
    declarations: [
        UploadDocumentComponent
    ],
    imports: [
        BrowserModule,
        UploadDocumentRoutingModule,




    ],
    exports: [UploadDocumentComponent,]
})
export class UploadModule { }
