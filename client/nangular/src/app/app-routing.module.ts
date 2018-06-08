import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';

export const routes: Routes = [
  // The router uses a first-match wins strategy when matching routes,
  // so more specific routes should be placed above less specific routes.
  { path: '', component: AppComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
