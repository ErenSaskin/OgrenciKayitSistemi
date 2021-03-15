import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { StudentModule } from '../shared/student.module';
import { StudentService } from '../shared/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  constructor(public service:StudentService, private toastr:ToastrService ) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(selected:StudentModule){
    this.service.formData = Object.assign({},selected);
    this.service.formData.dateOfReg = selected.dateOfReg.substring(0,4);
  }

  onDelete(id:number){

    if(confirm("Silmek istediğine emin misin?")){
      this.service.deleteStudent(id).subscribe(
        res=>{
          this.service.refreshList();
          this.toastr.error("Silindi.","Öğrenci");
        },
        err=>{console.log(err)}
      );
    }
  }
}
