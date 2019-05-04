import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';
import { StoreModule } from '@ngrx/store';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { UserService } from './services/user.service';
import { ReactiveFormsModule } from '@angular/forms';
import { QuestionsComponent } from './components/questions/questions.component';
import { QuestionComponent } from './components/questions/question/question.component';
import { QuestionService } from './services/question.service';
import { UserReducer } from './reducers/user.reducer';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    QuestionsComponent,
    QuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ToastrModule.forRoot(),
    StoreModule.forRoot({
      user: UserReducer
    })
  ],
  providers: [
    UserService,
    QuestionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
