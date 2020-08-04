import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { RegistrationSuccessfulComponent } from './components/registration-successful/registration-successful.component';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent },
  { path: 'registration-successful', component: RegistrationSuccessfulComponent },
  { path: '',   redirectTo: '/registration', pathMatch: 'full' }, // redirect to `first-component`
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
