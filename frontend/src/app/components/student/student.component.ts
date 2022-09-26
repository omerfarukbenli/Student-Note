import { Component, OnInit, TemplateRef } from '@angular/core';
import { Student } from 'src/app/models/student';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { StudentService } from 'src/app/services/student.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {


  formulario:any;
  tituloFormulario:string;
  pessoas:Student[];
  nomePessoa: string;
  id:number;

  visibilidadeTabela:boolean = true; //tablo gözüksün, gözükmesin diye yapılan şey
  visibilidadeFormlario:boolean = false;

  modalRef:BsModalRef;
  constructor(private studentService:StudentService, private modalService:BsModalService) { }

  ngOnInit(): void {
    this.studentService.PegarTodos().subscribe(resultado=>{
      this.pessoas = resultado;
  });
  this.tituloFormulario = "başlık"

    this.formulario = new FormGroup({
      nome:new FormControl(null),
      sobrenome:new FormControl(null),
      idade:new FormControl(null),
      profissao: new FormControl(null),
    });

}
ExibirFormularioCadastro():void{ //kayıt formunu göster
  this.visibilidadeTabela = false;
  this.visibilidadeFormlario = true;

  this.tituloFormulario = 'yeni kişi'; //ekleme
  this.formulario = new FormGroup({
    nome:new FormControl(null),
    sobrenome:new FormControl(null),
    idade:new FormControl(null),
    profissao: new FormControl(null),
  });
}
ExibirFormularioAtualizacao(id:number):void{
  this.visibilidadeTabela = false;
  this.visibilidadeFormlario = true;

  this.studentService.PegarPeloId(id).subscribe(resultado =>{
    this.tituloFormulario = `Düzenle ${resultado.name} ${resultado.lastName}`;
    this.formulario = new FormGroup({
      id: new FormControl(resultado.id),
      nome: new FormControl(resultado.name),
      sobrenome: new FormControl(resultado.lastName),
      idade: new FormControl(resultado.no),
      profissao: new FormControl(resultado.midTermExam),
      profissao2: new FormControl(resultado.finalExam),
      profissao3: new FormControl(resultado.lessonId),

    });
  });
}


EnviarFormulario():void{ //eklemek için
  const pessoa: Student = this.formulario.value;

  if(pessoa.id>0){
    this.studentService.AutalizarPessoa(pessoa).subscribe(resultado =>{

      this.visibilidadeFormlario = false;
      this.visibilidadeTabela = true;
      alert('güncellendi');
      this.studentService.PegarTodos().subscribe(registros =>{
        this.pessoas = registros;
      });

    });
  }
  else{


  this.studentService.SalvarPessoa(pessoa).subscribe(resultado=>{
    this.visibilidadeFormlario = false;
    this.visibilidadeTabela = true;
    alert('eklendi');
    this.studentService.PegarTodos().subscribe(registros =>{
      this.pessoas = registros;
    });
  });
}

}

Voltar():void{
  this.visibilidadeTabela = true;
  this.visibilidadeFormlario = false;
}


ExibirConfirmaExclusao(id:number, nomePessoa:string, conteudoModal:TemplateRef<any>): void{
this.modalRef = this.modalService.show(conteudoModal);
this.id = id;
this.nomePessoa = nomePessoa;
}



ExcluirPessao(id:number){
this.studentService.ExcluirPessoa(id).subscribe(resultado  =>{
this.modalRef.hide();
alert('silme başarılı');
this.studentService.PegarTodos().subscribe(registros=>{
  this.pessoas = registros;
});
});
}
}

