import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/services/question.service';
import { Question } from 'src/app/shared/question.model';
import { QuestionComponent } from './question/question.component';

import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { User } from '../../shared/user.model';
import { AppState } from '../../app.state';
import { Answer } from 'src/app/shared/answer.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import * as UserActions from '../../actions/user.actions';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnInit {
  state: Observable<User>;
  user: any;
  
  questionIndex: number;
  question: Question;
  questions: Question[] = null;
  constructor(private questionService: QuestionService, 
    private store: Store<AppState>,
    private toastr:ToastrService,
    private router: Router) { 
    this.state = store.select('user');    
  }

  ngOnInit() {
    this.state.subscribe(usr => this.user = usr);
    var self = this;

    self.questionIndex = 0;
    self.questionService.getQuestions().then(function(res){
      self.questions = res as Question[];
      if(self.questions){
        self.question = self.questions[self.questionIndex];
      }               
    });  
    this.resetFormData();
    
  }

  resetFormData(){
    this.questionService.formData = {
      UserId: this.user ? this.user.UserId : null,
      QuestionId: (this.question && this.question.QuestionId) ? this.question.QuestionId : null,
      ChoiceId: null
    };  

  }

  removeUserFromStore() {
    this.store.dispatch(new UserActions.RemoveUser() )
  }

  storePreviousAnswer(){        
    this.questionService.formData.QuestionId = this.question.QuestionId;
    this.questionService.formData.UserId = this.user.UserId;
    this.questionService.AnswerList.push(this.questionService.formData);
  }

  navigateToNextQuestion(){
    this.storePreviousAnswer();
    this.questionIndex++;    
    this.question = this.questions[this.questionIndex];    
    this.resetFormData();
  }

  submitAnswers(){
    this.questionService.submitAnswers().subscribe(
      (res:any)=>{
        if(res.Succeeded){                    
          this.toastr.success('New List of Answers created', 'Submission successful.');
          this.removeUserFromStore();
          this.router.navigate(['/user/registration']);
        } else{                      
          this.toastr.error(res.error.description, 'Submission failed.');                                
        }        
      },
      err=>{
        console.log(err);
      }
    );
  }
}
