import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { User } from '../shared/user.model';

export const ADD_USER       = '[USER] Add'
export const REMOVE_USER    = '[USER] Remove'

export class AddUser implements Action {
    readonly type = ADD_USER

    constructor(public payload: User) {}
}

export class RemoveUser implements Action {
    readonly type = REMOVE_USER

    constructor() {}
}


export type Actions = AddUser | RemoveUser