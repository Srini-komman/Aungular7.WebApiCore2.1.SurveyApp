import { Injectable } from '@angular/core';
import { Question } from '../shared/question.model';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.dev';
import { Answer } from '../shared/answer.model';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  baseUrl = environment.baseUrl;
  formData: Answer;
  AnswerList: Answer[] = [];
  
  constructor(private http:HttpClient) { 
    
  }

  getQuestions(){
    let url = this.baseUrl + 'Survey/Questions';
    return this.http.get(url).toPromise();
  }

  submitAnswers(){
    var body1 = [
      ...this.AnswerList
    ];
    var body = {
      Answers:this.AnswerList
    };
    let url = this.baseUrl + 'Survey/SubmitAnswers';
    return this.http.post(url, body);
  }
}
