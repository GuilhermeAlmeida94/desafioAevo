import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-aluno-search',
  templateUrl: './aluno-search.component.html',
  styleUrls: ['./aluno-search.component.css']
})
export class AlunoSearchComponent implements OnInit {

  @Input() searchNome: string;
  @Output() searchNomeChange = new EventEmitter<string>();

  @Output() getAlunos = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  searchInputChange($event): void {
    this.searchNomeChange.emit($event.target.value);
  }

  search(): void {
    this.getAlunos.emit();
  }

}
