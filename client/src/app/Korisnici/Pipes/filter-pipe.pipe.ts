import { Pipe, PipeTransform } from '@angular/core';
import { User } from '../worker-panel/worker/Model/User';

@Pipe({
  name: 'filterPipe'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, input: any): any {
    if (input) {
       return value.filter((val:User) => val.ime_prezime?.toLowerCase().startsWith(input));
     } else {
       return value;
     }
    }

}
