import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-aluno-search',
  templateUrl: './aluno-search.component.html',
  styleUrls: ['./aluno-search.component.css']
})
export class AlunoSearchComponent implements OnInit {

  formGroup: FormGroup;

  constructor(
    formBuilder: FormBuilder) {
      this.formGroup = formBuilder.group({
        nome: '',
      });
    }

  ngOnInit(): void {
  }

  search(): void {

  }

}
