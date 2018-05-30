import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { EffectsModule } from '@ngrx/effects';
import {
  RouterStateSerializer,
  StoreRouterConnectingModule,
} from '@ngrx/router-store';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { environment } from '../environments/environment';
// If you add any child modules, import them before AppRoutingModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { metaReducers, reducers } from './reducers';
import { CustomRouterStateSerializer } from './shared/utils';

@NgModule({
  declarations: [
    // View classes that belong to this module (components, directives, pipes).
    // Do not put any other kind of class in declarations; not NgModule
    // classes, not service classes, not model classes.
    AppComponent,
  ],
  exports: [
    // A subset of declarations that should be visible and useable in the
    // component templates of other modules.
  ],
  imports: [
    // Only NgModule classes belong in imports; do not put any other kind of
    // class here.
    BrowserModule,
    AppRoutingModule,

    // StoreModule.forRoot is imported once in the root module, accepting a reducer
    // function or object map of reducer functions. If passed an object of
    // reducers, combineReducers will be run creating your application
    // meta-reducer. This returns all providers for an @ngrx/store
    // based application.
    StoreModule.forRoot(reducers, { metaReducers }),

    // @ngrx/router-store keeps router state up-to-date in the store.
    StoreRouterConnectingModule.forRoot({
      // They stateKey defines the name of the state used by the router-store reducer.
      // This matches the key defined in the map of reducers.
      stateKey: 'router',
    }),

    // Keep the devtools import after import of StoreModule.
    //
    // Store devtools instrument the store retaining past versions of state
    // and recalculating new states. This enables powerful time-travel
    // debugging.
    //
    // To use the debugger, install the Redux Devtools extension for either
    // Chrome or Firefox.
    //
    // See https://github.com/zalmoxisus/redux-devtools-extension
    StoreDevtoolsModule.instrument({
      name: 'nAngular Store DevTools',
      logOnly: environment.production,
      maxAge: 50,
    }),

    // EffectsModule.forRoot() is imported once in the root module and
    // sets up the effects class to be initialized immediately when the
    // application starts.
    //
    // See https://github.com/ngrx/platform/blob/master/docs/effects/api.md#forroot
    EffectsModule.forRoot([]),
  ],
  providers: [
    // The `RouterStateSnapshot` provided by the `Router` is a large complex
    // structure. A custom RouterStateSerializer is used to parse the
    // `RouterStateSnapshot` provided by `@ngrx/router-store` to include
    // only the desired pieces of the snapshot.
    { provide: RouterStateSerializer, useClass: CustomRouterStateSerializer },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
