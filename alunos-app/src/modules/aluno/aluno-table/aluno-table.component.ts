import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Aluno } from 'src/shared/interfaces/aluno';
import { AlunoCreateEditModalComponent } from '../aluno-create-edit-modal/aluno-create-edit-modal.component';

const ELEMENT_DATA: Aluno[] = [
  {alunoId: 1, nome: 'Hydrogen', email: '1.0079'},
  {alunoId: 2, nome: 'Helium', email: '4.0026'},
  {alunoId: 3, nome: 'Lithium', email: '6.941'},
  {alunoId: 4, nome: 'Beryllium', email: '9.0122'},
  {alunoId: 5, nome: 'Boron', email: '10.811'},
  {alunoId: 6, nome: 'Carbon', email: '12.0107'},
  {alunoId: 7, nome: 'Nitrogen', email: '14.0067'},
  {alunoId: 8, nome: 'Oxygen', email: '15.9994'},
  {alunoId: 9, nome: 'Fluorine', email: '18.9984'},
  {alunoId: 10, nome: 'Neon', email: '20.1797'},
];

@Component({
  selector: 'app-aluno-table',
  templateUrl: './aluno-table.component.html',
  styleUrls: ['./aluno-table.component.css']
})
export class AlunoTableComponent implements OnInit {
  displayedColumns: string[] = ['alunoId', 'nome', 'email', 'edit'];
  dataSource = ELEMENT_DATA;

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
  }

  openEditModal(data: Aluno): void {
    const dialogRef = this.dialog.open(AlunoCreateEditModalComponent, {
      width: '250px',
      data
    });

    dialogRef.afterClosed().subscribe(result => { });
  }
}
