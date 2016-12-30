import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';
import { Http } from '@angular/http';

@Injectable()
export class MovieService {
    private url = 'http://www.omdbapi.com/?';

    constructor(private http: Http) {
    }

    getMoviesByTitle(title: string, page?: number): Observable<any> {
        page = page || 1;
        return this.http.get(this.url + `s=${title}&page=${page}`)
            .map(res => res.json().Search);
    }

    getMovieById(movieId: string) {
        return this.http.get(this.url + `i=${movieId}`)
            .map(res => res.json())
    }

}
