import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgControlStatus } from '@angular/forms';
import { EnumDictionary } from '../../custom-types/enum-dictionary';
import { validateNpiNumber } from '../../validators/npi-number';
import { validatePhoneNumber } from '../../validators/phone-number';
import { CustomValidatorTags } from 'src/app/validators/custom-validators';
import { RegistrationService, RegistrationModel } from 'src/app/services/registration-service';
import { Router } from '@angular/router';

export enum FormKeys {
  FirstName = "FirstName",
  LastName = "LastName",
  NpiNumber = "NpiNumber",
  StreetOne = "StreetOne",
  StreetTwo = "StreetTwo",
  City = "City",
  State = "State",
  Zip = "Zip",
  Phone = "Phone",
  Email = "Email"
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public FormKeys = FormKeys;

  public registrationForm: FormGroup;
  public stateAbbreviations = [
    'AL','AK','AS','AZ','AR','CA','CO','CT','DE','DC','FM','FL','GA',
    'GU','HI','ID','IL','IN','IA','KS','KY','LA','ME','MH','MD','MA',
    'MI','MN','MS','MO','MT','NE','NV','NH','NJ','NM','NY','NC','ND',
    'MP','OH','OK','OR','PW','PA','PR','RI','SC','SD','TN','TX','UT',
    'VT','VI','VA','WA','WV','WI','WY'
   ];

  private fieldLabels: EnumDictionary<FormKeys, string> = null;

  constructor(
      private fb: FormBuilder,
      private registrationService: RegistrationService,
      private router: Router) {
    this.fieldLabels = this.buildFieldLabels();
  }

  ngOnInit(): void {
    this.registrationForm = this.buildForm();
  }

  onSubmit(): void {
    if (!this.registrationForm.errors) {

      const serviceModel = this.buildRegistrationModel();

      this.registrationService.register(serviceModel).subscribe(result =>  {
        if (result) {
          this.router.navigate(['registration-successful']);
        }
        // TODO - settle on desired error model
        else {
          alert('An error occurred while submitting this form.');
        }
      });
    }
  }

  public canSubmit(): boolean {
    return this.registrationForm.status === 'VALID';
  }

  public GetFieldLabel(key: FormKeys): string {
    return this.fieldLabels[key];
  }

  public ShouldShowFieldErrors(key: FormKeys): boolean {
    const control = this.registrationForm.get(key);

    return control.invalid && (control.dirty || control.touched);
  }

  public GetFieldErrors(key: FormKeys): string[] {
    const control = this.registrationForm.get(key);

    const errors = [];

    if (!control.errors) {
      return errors;
    }

    if (!!control.errors.required) {
      errors.push('This field is required.');
    }

    if (!!control.errors.email) {
      errors.push('Must provide a valid email address.');
    }

    if (!!control.errors[CustomValidatorTags.NpiNumber]) {
      errors.push('NPI number must be a ten numeric digits.');
    }

    if (!!control.errors[CustomValidatorTags.ZipCode]) {
      errors.push('Invalid ZIP code.');
    }

    if (!!control.errors[CustomValidatorTags.PhoneNumber]) {
      errors.push('Phone number must be in format: 555-555-1212');
    }

    return errors;
  }

  private buildForm(): FormGroup {
    const form = this.fb.group({
      [FormKeys.FirstName]: ['', Validators.required],
      [FormKeys.LastName]: ['', Validators.required],
      [FormKeys.StreetOne]: ['', Validators.required],
      [FormKeys.StreetTwo]: [''],
      [FormKeys.City]: ['', Validators.required],
      [FormKeys.State]: ['', Validators.required],
      [FormKeys.Zip]: ['', Validators.required],
      [FormKeys.NpiNumber]: ['', [Validators.required, validateNpiNumber, Validators.maxLength(10)]],
      [FormKeys.Phone]: ['', [Validators.required, validatePhoneNumber]],
      [FormKeys.Email]: ['', [Validators.required, Validators.email]]
    });

    return form;
  }

  private buildFieldLabels(): EnumDictionary<FormKeys, string> {
    const labelMap: EnumDictionary<FormKeys, string> = {
      [FormKeys.FirstName]: 'First Name',
      [FormKeys.LastName]: 'Last Name',
      [FormKeys.NpiNumber]: 'NPI Number',
      [FormKeys.StreetOne]: 'Street Address',
      [FormKeys.StreetTwo]: 'Additional Street Address',
      [FormKeys.City]: 'City',
      [FormKeys.State]: 'State',
      [FormKeys.Zip]: 'Zip Code',
      [FormKeys.Phone]: 'Phone Number',
      [FormKeys.Email]: 'Email Address',
    };

    return labelMap;
  }

  private buildRegistrationModel(): RegistrationModel {
    const model: RegistrationModel = {
      firstName: this.registrationForm.get(FormKeys.FirstName).value,
      lastName: this.registrationForm.get(FormKeys.LastName).value,
      npiNumber: this.registrationForm.get(FormKeys.NpiNumber).value,
      streetOne: this.registrationForm.get(FormKeys.StreetOne).value,
      streetTwo: this.registrationForm.get(FormKeys.StreetTwo).value,
      city: this.registrationForm.get(FormKeys.City).value,
      state: this.registrationForm.get(FormKeys.State).value,
      zipCode: this.registrationForm.get(FormKeys.Zip).value,
      phone: this.registrationForm.get(FormKeys.Phone).value,
      email: this.registrationForm.get(FormKeys.Email).value,
    };

    return model;
  }
}
