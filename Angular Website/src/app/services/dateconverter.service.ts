import { Injectable } from '@angular/core';



@Injectable()
export class DateConverterService {
    constructor() { }

    dateToString(value: Date): string | null {
        console.log('this is from the datetostring service');
        console.log(value);
        if (value == null) {
            return null;
        }
        if (typeof (value) === 'object')
            return this._to2digit(value.getMonth() + 1) + '/' + this._to2digit(value.getDate()) + '/' + value.getFullYear();
    }

    private _to2digit(n: number): string {
        return ('00' + n).slice(-2);
    }

    intToDate(value){
        debugger;
        const d = value % 100;
        const m = (value / 100);
        const y = value / 10000;

        return this._to2digit(m) + '/' + this._to2digit(d) + '/' + y;

    }


    // ExcelDateToJSDate(serial) {
    //     debugger;
    //     var utc_days = Math.floor(serial - 25569);
    //     var utc_value = utc_days * 86400;
    //     var date_info = new Date(utc_value * 1000);

    //     var fractional_day = serial - Math.floor(serial) + 0.0000001;

    //     var total_seconds = Math.floor(86400 * fractional_day);

    //     var seconds = total_seconds % 60;

    //     total_seconds -= seconds;

    //     var hours = Math.floor(total_seconds / (60 * 60));
    //     var minutes = Math.floor(total_seconds / 60) % 60;

    //     return new Date(date_info.getFullYear(), date_info.getMonth(), date_info.getDate(), hours, minutes, seconds);
    // }

    ExcelDateToJSDate(date) {
        return new Date((date - (25567 + 2)) * 86400 * 1000);
        // return new Date(Math.round((date - 25569) * 86400 * 1000));
    }


}
