import { FormControl } from '@angular/forms';
import { CustomValidatorTags } from '../validators/custom-validators';

export function validateNpiNumber(c: FormControl) {
  const trimmed = (<string>c.value).trim();

  if (trimmed.trim().length !== 10) {
    return {
      [CustomValidatorTags.NpiNumber]: 'Incorrect number of digits.'
    };
  }

  for (let i=0; i<trimmed.length; i++) {
    if (Number.isNaN(Number.parseInt(trimmed[i], 10))) {
      return {
        [CustomValidatorTags.NpiNumber]: 'NPI number can only contain digits.'
      };
    }
  }

  return null;
}
