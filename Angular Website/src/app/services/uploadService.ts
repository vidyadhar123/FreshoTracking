import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpHeaderResponse, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';


@Injectable()
export class UploadService {
    constructor(private http: HttpClient) { }

    getHeader() {
        const newHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
        return newHeaders;
    }


    get(url: string, itemId: number, clear: number, calc: number): Observable<any> {
        return this.http.get(url)
            .pipe(map((response: Response) => response),
                catchError(this.handleError)
            );
    }




    insertCustomerRecord(url: string, body): Observable<any> {
        debugger;
        return this.http.post(url, body, { headers: this.getHeader() })
            .pipe(
                catchError(this.handleError)
            );
    }

    insertInvoiceListRecord(url: string, body): Observable<any> {
        return this.http.post(url, body, { headers: this.getHeader() })
            .pipe(
                catchError(this.handleError)
            );
    }

    insertRemitListRecord(url: string, body): Observable<any> {
        debugger;
        return this.http.post(url, body, { headers: this.getHeader() })
            .pipe(
                catchError(this.handleError)
            );
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error || 'Server error');
    }




}
