import {Action} from '@ngrx/store';
import {User} from '../shared/user.model';
import * as UserActions from '../actions/user.actions';

export function UserReducer(state: User, action:UserActions.Actions){
    switch(action.type) {
        case UserActions.ADD_USER:
            state = action.payload
            return state;     
        case UserActions.REMOVE_USER:
            state = undefined;
            return state;     
        default:
            return state;
    }
}

