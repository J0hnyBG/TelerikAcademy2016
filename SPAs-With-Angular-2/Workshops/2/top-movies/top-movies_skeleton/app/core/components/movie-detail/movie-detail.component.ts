import { Component, Input, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie-service';
import { Movie } from '../../models/movie.model';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
    templateUrl: 'movie-detail.component.html',
    selector: 'mdb-movie-detail'
})

export class MovieDetailComponent implements OnInit {
    private movie: Movie;
    private loading: boolean;
    @Input() movieId: string;

    constructor(private movieService: MovieService,
                private route: ActivatedRoute) {
        this.loading = true;
        this.movie = new Movie();
    }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.movieService.getMovieById(params['movieId']))
            .subscribe((movie: Movie) => {
                this.movie = movie;
                this.loading = false;
            });
    }
}
