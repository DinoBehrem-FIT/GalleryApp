import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Galleriana';
  user: boolean = false;
  // : boolean = localStorage.getItem('authentication-key') != ''

  getUser(value: any) {
    this.user = value == '';
  }
}
