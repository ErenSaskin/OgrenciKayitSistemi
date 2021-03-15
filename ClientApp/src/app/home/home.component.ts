import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  public students: Students[];
  sayi:number = 0;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Students[]>(baseUrl + 'api/student').subscribe(result => {
      this.students = result;
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
  dateOfReg: string;
  
}