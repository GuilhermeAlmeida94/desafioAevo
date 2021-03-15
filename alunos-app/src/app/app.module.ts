import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { ToolbarComponent } from 'src/modules/main/toolbar/toolbar.component';
import { AlunoTableComponent } from 'src/modules/aluno/aluno-table/aluno-table.component';
import { AlunoCreateButtonComponent } from 'src/modules/aluno/aluno-create-button/aluno-create-button.component';
import { AlunoCreateEditModalComponent } from 'src/modules/aluno/aluno-create-edit-modal/aluno-create-edit-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlunoSearchComponent } from 'src/modules/aluno/aluno-search/aluno-search.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    AlunoTableComponent,
    AlunoCreateButtonComponent,
    AlunoCreateEditModalComponent,
    AlunoSearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
