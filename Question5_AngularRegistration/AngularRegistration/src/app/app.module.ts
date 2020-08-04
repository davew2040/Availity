import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import {
  MatInputModule,
} from '@angular/material/input';
import {
  MatButtonModule,
} from '@angular/material/button';
import {
  MatSelectModule,
} from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { RegistrationSuccessfulComponent } from './components/registration-successful/registration-successful.component';
import { RegistrationService } from './services/registration-service';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    RegistrationSuccessfulComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    BrowserAnimationsModule
  ],
  exports: [
    MatInputModule,
    MatButtonModule
  ],
  providers: [RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
