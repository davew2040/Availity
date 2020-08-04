import { Observable, from, of } from 'rxjs';
import { delay } from 'rxjs/operators';

export interface RegistrationModel {
  firstName: string;
  lastName: string;
  npiNumber: string;
  streetOne: string;
  streetTwo: string;
  city: string;
  state: string;
  zipCode: string;
  phone: string;
  email: string;
}

// Just a mock service to return a true after a short delay.
export class RegistrationService {
  public register(model: RegistrationModel): Observable<boolean> {
    return of(true).pipe(delay(1000));
  }
}
