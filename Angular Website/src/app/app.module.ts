import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadModule } from './upload document/upload.module';
import { HeaderModule } from './header/header.module';
import { FooterModule } from './footer/footer.module';
import { UploadService } from './services/uploadService';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DateConverterService } from './services/dateconverter.service';
import { DemoMaterialModule } from './material.module';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UploadModule,
    HeaderModule,
    FooterModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()

  ],
  providers: [UploadService,DateConverterService],
  bootstrap: [AppComponent],
})
export class AppModule { }
