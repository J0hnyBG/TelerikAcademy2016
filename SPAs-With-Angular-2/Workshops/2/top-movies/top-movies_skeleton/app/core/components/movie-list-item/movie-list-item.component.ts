import { Component, Input } from '@angular/core';
import { Movie } from '../../models/movie.model';

@Component({
    templateUrl: 'movie-list-item.component.html',
    selector: '[mdb-movie-list-item]'
})

export class MovieListItemComponent {
    @Input() movie: Movie;

    constructor() {
    }
}
