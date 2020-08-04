import { FormControl } from '@angular/forms';
import { CustomValidatorTags } from './custom-validators';

export function validatePhoneNumber(c: FormControl) {
  const phonePatterns: RegExp[] = [];

  const trimmed = (<string>c.value).trim();

  phonePatterns.push(/^\d{10}$/);
  phonePatterns.push(/^\d{3}-\d{3}-\d{4}$/);
  phonePatterns.push(/^\(\d{3}\)-\d{3}-\d{4}$/);
  phonePatterns.push(/^\(\d{3}\)\d{3}-\d{4}$/);

  for (const pattern of phonePatterns) {
    if (pattern.test(trimmed)) {
      return null;
    }
  }

  return {
    [CustomValidatorTags.PhoneNumber]: 'Invalid phone number.'
  };
}
