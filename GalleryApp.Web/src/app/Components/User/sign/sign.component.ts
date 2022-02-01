import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/Services/User/user.service';
import { LoginVM } from 'src/app/ViewModels/User/LoginVM';

@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.css'],
})
export class SignComponent implements OnInit {
  login!: FormGroup;
  errorMessage: string = '';
  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.login = this.formBuilder.group({
      username: '',
      password: '',
    });
  }

  Login() {
    if (this.userService.Login(this.login.value as LoginVM)) {
      this.errorMessage = 'You are not registered!';
    } else {
      this.errorMessage = '';
    }
  }
}
