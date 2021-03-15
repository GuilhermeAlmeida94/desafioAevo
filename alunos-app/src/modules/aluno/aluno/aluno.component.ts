import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/shared/interfaces/aluno';
import { AlunoService } from 'src/shared/services/aluno.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit {

  searchNome = '';
  alunos: Aluno[] = null;

  constructor(
    private alunoService: AlunoService) { }

  ngOnInit() {
  }

  getAlunos(): void {
    const query = this.searchNome ?
      `?$filter=contains(tolower(nome), tolower('${this.searchNome}'))` : this.searchNome;

    this.alunoService.retrieveAll(query)
      .subscribe(
        result => this.alunos = result,
        _ => this.alunos = null
      );
  }
}
