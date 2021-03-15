import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Aluno } from 'src/shared/interfaces/aluno';
import { AlunoCreateEditModalComponent } from '../aluno-create-edit-modal/aluno-create-edit-modal.component';

@Component({
  selector: 'app-aluno-table',
  templateUrl: './aluno-table.component.html',
  styleUrls: ['./aluno-table.component.css']
})
export class AlunoTableComponent implements OnInit {

  displayedColumns: string[] = ['alunoId', 'nome', 'email', 'edit'];

  @Input() alunos: Aluno[] = null;
  @Output() getAlunos = new EventEmitter();

  constructor(
    public dialog: MatDialog) {}

  ngOnInit(): void {
    this.getAlunos.emit();
  }

  openEditModal(data: Aluno): void {
    const dialogRef = this.dialog.open(AlunoCreateEditModalComponent, {
      width: '250px',
      data
    });

    dialogRef.afterClosed().subscribe(
      result => {
        if (result) {
          this.getAlunos.emit(null);
        }
      }
    );
  }
}
