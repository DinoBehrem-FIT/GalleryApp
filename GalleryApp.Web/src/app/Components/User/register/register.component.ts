import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/Services/User/user.service';
import { RegistrationVM } from 'src/app/ViewModels/User/RegistrationVM';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registration!: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.registration = this.formBuilder.group({
      firstName: '',
      lastName: '',
      username: '',
      password: '',
    });
  }

  Register() {
    this.userService.Register(this.registration.value as RegistrationVM);
  }
}
