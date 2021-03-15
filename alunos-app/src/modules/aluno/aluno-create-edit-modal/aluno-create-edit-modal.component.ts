import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Aluno } from 'src/shared/interfaces/aluno';

@Component({
  selector: 'app-aluno-create-edit-modal',
  templateUrl: './aluno-create-edit-modal.component.html',
  styleUrls: ['./aluno-create-edit-modal.component.css']
})
export class AlunoCreateEditModalComponent implements OnInit {

  modalType: string;
  formGroup: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<AlunoCreateEditModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Aluno,
    formBuilder: FormBuilder) {
      this.modalType = data ? 'Editar' : 'Cadastrar';
      this.formGroup = formBuilder.group({
        nome: [data ? data.nome : '', [Validators.required, Validators.maxLength(250)]],
        email: [data ? data.email : '', Validators.email],
      });
    }

  ngOnInit(): void {
  }

  close(): void {
    this.dialogRef.close();
  }

  save(): void {
    const aluno = {
      nome: this.formGroup.value.nome,
      email: this.formGroup.value.email
    } as Aluno;

    if (this.data) {
      aluno.alunoId = this.data.alunoId;
    } else {
    }
    this.dialogRef.close();
  }
}
