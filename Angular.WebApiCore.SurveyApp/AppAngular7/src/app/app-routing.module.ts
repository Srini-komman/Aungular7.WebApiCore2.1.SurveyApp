import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { QuestionComponent } from './components/questions/question/question.component';

const routes: Routes = [
  {path:'', redirectTo:'/user/registration', pathMatch:'full'},
  {
    path:'user', component:UserComponent,
    children:[
      {path:'registration', component:RegistrationComponent}    
    ]
  },
  {
    path:'questions', component:QuestionsComponent,    
  }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
