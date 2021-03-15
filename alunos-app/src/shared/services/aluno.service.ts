import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Aluno } from '../interfaces/aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  url: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.url = `${environment.url}/alunos`;
  }

  retrieveAll(query?: string): Observable<Aluno[]> {
    if (!query) { query = ''; }
    return this.httpClient.get<Aluno[]>(`${this.url}${query}`);
  }

  create(aluno: Aluno): Observable<Aluno> {
    return this.httpClient.post<Aluno>(this.url, aluno);
  }

  update(aluno: Aluno): Observable<Aluno> {
  return this.httpClient.put<Aluno>(`${this.url}/${aluno.alunoId}`, aluno);
  }
}
