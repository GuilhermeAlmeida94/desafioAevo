import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { ToolbarComponent } from 'src/modules/main/toolbar/toolbar.component';
import { AlunoTableComponent } from 'src/modules/aluno/aluno-table/aluno-table.component';
import { AlunoCreateButtonComponent } from 'src/modules/aluno/aluno-create-button/aluno-create-button.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    AlunoTableComponent,
    AlunoCreateButtonComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
