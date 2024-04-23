import { Component } from '@angular/core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrl: './student.component.scss'
})
export class StudentComponent{

  constructor(

  ){}

  showProfileTab = true;
  showDocumentsTab = false;

  showProfile() {
    this.showProfileTab = true;
    this.showDocumentsTab = false;
  }

  showDocuments() {
    this.showProfileTab = false;
    this.showDocumentsTab = true;
  }
}
