import { Component, Input, OnInit } from '@angular/core';
import { AuthHelper } from 'src/app/ViewModels/Helpers/AuthenticationHelper';
import { LoginInfoVM } from 'src/app/ViewModels/Helpers/LoginInfoVM';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  user: LoginInfoVM;

  constructor() {}
  @Input() logedUser: any;

  ngOnInit(): void {}

  Logout() {
    localStorage.removeItem('Authentication-token');
  }

  LoginInfo(): LoginInfoVM {
    return AuthHelper.getLoginInfo();
  }
}
