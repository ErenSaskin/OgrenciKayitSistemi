import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { StudentModule } from './student.module';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

constructor(private http: HttpClient) { }
readonly baseUrl = 'https://localhost:44331/api/student/'

formData: StudentModule = new StudentModule();
list:StudentModule[];


postStudent(){
  return this.http.post(this.baseUrl+"create/",{'name':this.formData.name,'surname':this.formData.surname,'dateOfReg':this.formData.dateOfReg+"-10-01"});
}
putStudent(){
  return this.http.put(this.baseUrl+"update/"+this.formData.id,{'name':this.formData.name,'surname':this.formData.surname,'dateOfReg':this.formData.dateOfReg+"-10-01"});
}

deleteStudent(id:number){
  return this.http.delete(this.baseUrl+"delete/"+id);
}

refreshList(){
 this.http.get(this.baseUrl).toPromise().then(res=>this.list = res as StudentModule[]);
}

}
