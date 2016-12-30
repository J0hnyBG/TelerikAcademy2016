import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort'
})
export class SortPipe implements PipeTransform {
    transform(items: any[], sortType: any[]) {
        let property = sortType[0];
        let order = +sortType[1];
        return items.sort((a: any, b : any) => {
            if (a[property] > b[property]) {
                return order;
            } else if (a[property] < b[property]) {
                return -order;
            } else {
                return 0;
            }
        });
    }
}