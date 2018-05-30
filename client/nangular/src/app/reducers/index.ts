// The createSelector function creates efficient selectors that are memorized
// and only recompute when arguments change. The created selectors can also
// be composed together to select different pieces of state.
import {
  ActionReducerMap,
  createSelector,
  createFeatureSelector,
  ActionReducer,
  MetaReducer,
} from '@ngrx/store';

// We will build a top level reducer based on the current environment.
import { environment } from '../../environments/environment';

// Router state is also kept in the store.
// This is useful for time travel debugging of navigation events.
import { RouterStateUrl } from '../shared/utils';
import * as fromRouter from '@ngrx/router-store';

// storeFreeze prevents state from being mutated. When mutation occurs, an
// exception will be thrown. This is useful during development mode to
// ensure that none of the reducers accidentally mutates the state.
import { storeFreeze } from 'ngrx-store-freeze';

// We treat each reducer like a table in a database. This means our
// top level state interface is just a map of keys to inner state types.
export interface State {
  router: fromRouter.RouterReducerState<RouterStateUrl>;
}

// Our state is composed of a map of action reducer functions.
// These reducer functions are called with each dispatched action
// and the current or initial state and return a new immutable state.
export const reducers: ActionReducerMap<State> = {
  router: fromRouter.routerReducer,
};

// console.log all actions
export function logger(reducer: ActionReducer<State>): ActionReducer<State> {
  return function(state: State, action: any): State {
    console.log('state', state);
    console.log('action', action);

    return reducer(state, action);
  };
}

// By default, @ngrx/store uses combineReducers with the reducer map to compose
// the root meta-reducer. To add more meta-reducers, provide an array of meta-reducers
// that will be composed to form the root meta-reducer.
export const metaReducers: MetaReducer<State>[] = !environment.production
  ? [logger, storeFreeze]
  : [];
