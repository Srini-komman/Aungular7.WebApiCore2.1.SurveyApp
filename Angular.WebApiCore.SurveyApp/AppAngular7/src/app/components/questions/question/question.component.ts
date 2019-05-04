import { Component, OnInit, Input } from '@angular/core';
import { Question } from '../../../shared/question.model';
import { QuestionService } from 'src/app/services/question.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  @Input() question: Question = null;
  @Input() questionIndex: number = null;

  constructor(private questionService: QuestionService) { }

  ngOnInit() {
  }

}
