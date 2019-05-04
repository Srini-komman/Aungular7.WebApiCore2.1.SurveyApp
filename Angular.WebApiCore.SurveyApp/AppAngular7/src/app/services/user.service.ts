import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.dev';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.baseUrl;
  constructor(private fb:FormBuilder, private http:HttpClient) { }

  formModel = this.fb.group({
    NickName:['', Validators.required]
  });

  registerUser(){
    var body = {
      NickName: this.formModel.value.NickName
    };
    let url = this.baseUrl + 'Survey/Register';
    return this.http.post(url, body);
  }
}
