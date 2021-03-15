import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Aluno } from 'src/shared/interfaces/aluno';
import { AlunoService } from 'src/shared/services/aluno.service';

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
    private alunoService: AlunoService,
    formBuilder: FormBuilder) {
      this.modalType = data ? 'Editar' : 'Cadastrar';
      this.formGroup = formBuilder.group({
        nome: [data ? data.nome : '', [Validators.required, Validators.maxLength(250)]],
        email: [data ? data.email : '', Validators.email],
      });
    }

  get nomeControl(): any { return this.formGroup.get('nome'); }
  get emailControl(): any { return this.formGroup.get('email'); }

  ngOnInit(): void {
  }

  close(): void {
    this.dialogRef.close();
  }

  nomeRequiredError(): boolean {
    return this.nomeControl.invalid && this.nomeControl.errors.required;
  }
  nomeRequiredErrorText(): string {
    return 'O campo nome é obrigatório';
  }

  nomeMaxLengthError(): boolean {
    return this.nomeControl.invalid && this.nomeControl.errors.maxlength !== undefined;
  }
  nomeMasLengthErrorText(): string {
    return `O campo nome deve ter no máximo ${this.nomeControl.errors.maxlength.requiredLength} caracteres`;
  }

  emailInvalidError(): boolean {
    return this.emailControl.invalid && this.emailControl.errors.email !== undefined;
  }
  emailInvalidErrorText(): string {
    return `O campo e-mail está inválido`;
  }

  save(): void {
    const aluno = {
      nome: this.formGroup.value.nome,
      email: this.formGroup.value.email
    } as Aluno;

    if (this.data) {
      aluno.alunoId = this.data.alunoId;

      this.alunoService.update(aluno)
        .subscribe(
          _ => this.dialogRef.close(true),
          error => console.log(error)
        );
    } else {
      this.alunoService.create(aluno)
      .subscribe(
        _ => this.dialogRef.close(true),
        error => console.log(error)
      );
    }
  }
}
