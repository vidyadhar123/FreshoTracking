import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpHeaderResponse, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';


@Injectable()
export class UploadService {
    constructor(private http: HttpClient) { }

    get(url: string, itemId: number, clear: number, calc: number): Observable<any> {
        return this.http.get(url)
            .pipe(map((response: Response) => response),
                catchError(this.handleError)
            );
    }

    post(url: string, body): Observable<any> {
        return this.http.put(url, body)
            .pipe(map((response: Response) => response.json()),
                catchError(this.handleError)
            );
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error || 'Server error');
    }

}
