import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { AlunoTableComponent } from 'src/modules/aluno/aluno-table/aluno-table.component';
import { AlunoCreateButtonComponent } from 'src/modules/aluno/aluno-create-button/aluno-create-button.component';
import { AlunoCreateEditModalComponent } from 'src/modules/aluno/aluno-create-edit-modal/aluno-create-edit-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlunoSearchComponent } from 'src/modules/aluno/aluno-search/aluno-search.component';
import { AlunoComponent } from './aluno/aluno.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  declarations: [
    AlunoCreateButtonComponent,
    AlunoCreateEditModalComponent,
    AlunoSearchComponent,
    AlunoTableComponent,
    AlunoComponent
  ],
  exports: [
    AlunoComponent
  ]
})
export class AlunoModule { }
