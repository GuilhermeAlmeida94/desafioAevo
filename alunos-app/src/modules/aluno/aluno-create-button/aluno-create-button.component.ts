import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlunoCreateEditModalComponent } from '../aluno-create-edit-modal/aluno-create-edit-modal.component';

@Component({
  selector: 'app-aluno-create-button',
  templateUrl: './aluno-create-button.component.html',
  styleUrls: ['./aluno-create-button.component.css']
})
export class AlunoCreateButtonComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
  }

  openCreateModal(): void {
    const dialogRef = this.dialog.open(AlunoCreateEditModalComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => { });
  }

}
