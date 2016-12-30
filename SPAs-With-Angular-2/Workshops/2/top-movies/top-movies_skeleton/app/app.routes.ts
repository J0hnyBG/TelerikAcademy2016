import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { MovieDetailComponent } from './core/components/movie-detail/movie-detail.component';
import { MovieListComponent } from './core/components/movies-list/movies-list.component';

const appRoutes: Routes = [
    { path: 'home', component: MovieListComponent },
    { path: '', component: MovieListComponent, pathMatch: 'full' },
    { path: 'movie/:movieId', component: MovieDetailComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);