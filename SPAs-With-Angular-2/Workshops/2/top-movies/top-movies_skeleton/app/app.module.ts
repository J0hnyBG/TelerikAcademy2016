import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { AppComponent } from './app.component';
import { Ng2BootstrapModule } from 'ng2-bootstrap';
import { MovieListComponent } from './core/components/movies-list/movies-list.component';
import { MovieService } from './core/services/movie-service';
import { MovieListItemComponent } from './core/components/movie-list-item/movie-list-item.component';
import { SortPipe } from './core/pipes/sort-movie.pipe';
import { FooterComponent } from './core/components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { MovieDetailComponent } from './core/components/movie-detail/movie-detail.component';
import { routing } from './app.routes';
import { AcStar } from './core/components/star-rating/star';
import { AcStars } from './core/components/star-rating/stars';

@NgModule({
    imports: [
        BrowserModule,
        Ng2BootstrapModule,
        HttpModule,
        routing,
        InfiniteScrollModule,
        RouterModule
    ],
    declarations: [
        AppComponent,
        MovieListComponent,
        MovieListItemComponent,
        SortPipe,
        MovieDetailComponent,
        FooterComponent,
        AcStar,
        AcStars
    ],
    providers: [
        MovieService
    ],
    // put all the needed data here
    bootstrap: [AppComponent]
})
export class AppModule {
}
