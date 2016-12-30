import { Component, OnInit } from '@angular/core';
import { Movie } from '../../models/movie.model';
import { MovieService } from '../../services/movie-service';

@Component({
    templateUrl: 'movies-list.component.html',
    selector: 'mdb-movie-list',
    styleUrls: ['movies-list.component.css']
})

export class MovieListComponent implements OnInit {
    private movies: Movie[];
    private pageTitle: string;
    private currentPage: number;
    private sort: string;
    private order: string;
    private search: string;
    private loading: boolean;

    constructor(private movieService: MovieService) {
        this.movies = [];
        this.currentPage = 1;

    }

    ngOnInit() {
        this.doSearch('');
    }

    doSearch(title: string) {
        this.loading = true;
        this.movieService.getMoviesByTitle(title)
            .subscribe(res => {
                this.loading = false;
                if (res) {
                    this.currentPage = 1;
                    this.movies = res;
                }
            })
    }

    onScroll() {
        this.currentPage++;
        this.loading = true;

        this.movieService.getMoviesByTitle(this.search, this.currentPage)
            .subscribe(res => {
                if (res) {
                    this.loading = false;
                    this.movies = this.movies.concat(res);
                }
        })
    }
}
