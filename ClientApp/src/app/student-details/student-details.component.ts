import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html'
})
export class StudentDetailsComponent{

    public students: Students[];
    public nSsystem: NSsystem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Students[]>(baseUrl + 'api/student').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
    http.get<NSsystem[]>(baseUrl + 'api/newstudentsystem').subscribe(result => {
      this.nSsystem = result;
    }, error => console.error(error));
  }

}

interface Students {

  id: string;
  number: string;
  name: string;
  surname: string;
  class: string;
  email: string;
  dateOfReg: Date;
  
}
interface NSsystem {

  id: string;
  number: string;
  name: string;
  surname: string;
  class: string;
  email: string;
  dateOfReg: Date;
  password:string;
}