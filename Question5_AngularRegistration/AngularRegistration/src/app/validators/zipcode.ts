import { FormControl } from '@angular/forms';
import { CustomValidatorTags } from './custom-validators';

export function validateNpiNumber(c: FormControl) {
  const zipCodePattern = /^\d{5}$|^\d{5}-\d{4}$/;
  const trimmed = (<string>c.value).trim();

  if (!zipCodePattern.test(trimmed)) {
    return {
      [CustomValidatorTags.ZipCode]: 'Invalid ZIP code.'
    };
  }
  else {
    return null;
  }
}
