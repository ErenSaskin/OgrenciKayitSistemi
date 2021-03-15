
import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/shared/student.service';
import { FormsModule, NgForm } from '@angular/forms';
import { StudentModule } from 'src/app/shared/student.module';
import { ToastrService } from 'ngx-toastr';
import { NULL_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss']
})
export class StudentFormComponent implements OnInit {

  constructor(public service: StudentService, private toastr:ToastrService) { 

  }

  ngOnInit(): void {
    
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == "")
      this.insertRecord(form);  
    else
      this.updateRecord(form);  
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new StudentModule();
  }

  insertRecord(form:NgForm){
    this.service.postStudent().subscribe(
      res=>{
        this.resetForm(form);
        
        this.service.refreshList();
        this.toastr.success('Başarıyla eklendi.','Öğrenci');
        //this.service.getStudent().subscribe(res=>{},err=>{console.log(err);});
      },
      err=>{console.log(err);}
    )
  }

  updateRecord(form:NgForm){
    this.service.putStudent().subscribe(
      res=>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Başarıyla güncellendi.','Öğrenci');
        //this.service.getStudent().subscribe(res=>{},err=>{console.log(err);});
      },
      err=>{console.log(err);}
    )
  }

}




