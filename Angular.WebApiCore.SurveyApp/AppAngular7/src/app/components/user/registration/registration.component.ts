import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { element } from '@angular/core/src/render3';
import { ToastrService } from 'ngx-toastr';

import { Store } from '@ngrx/store';
import { AppState } from '../../../app.state';
import { User } from '../../../shared/user.model'
import * as UserActions from '../../../actions/user.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(public userService: UserService, 
    private store: Store<AppState>, 
    private toastr:ToastrService,
    private router: Router) { }

  addUserToStore(user: User) {
    this.store.dispatch(new UserActions.AddUser(user) )
  }

  ngOnInit() {
  }

  onSubmit(){
    this.userService.registerUser().subscribe(
      (res:any)=>{
        if(res.Succeeded){
          this.addUserToStore(res.data)
          this.toastr.success('New Nickname created', 'Registration successful.');
          this.router.navigate(['/questions']);
          //navigate to Questions
        } else{
          
            switch(res.error.code){
              case 'DuplicateNickName':
                this.toastr.error('Nickname is already taken', 'Registration failed.');
                break;
              default:
                this.toastr.error(res.error.description, 'Registration failed.');
            }
                    
        }
        
      },
      err=>{
        console.log(err);
      }
    );
  }

}
