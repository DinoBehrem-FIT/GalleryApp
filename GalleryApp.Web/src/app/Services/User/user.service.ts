import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthTokenVM } from 'src/app/ViewModels/Authorization/AuthTokenVM';
import { LoginVM } from 'src/app/ViewModels/User/LoginVM';
import { RegistrationVM } from 'src/app/ViewModels/User/RegistrationVM';
import { UserVM } from 'src/app/ViewModels/User/UserVM';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  url: string = 'https://localhost:44355/Authentication';
  options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient, private router: Router) {}

  Register(user: RegistrationVM): any {
    this.http
      .post<RegistrationVM>(this.url + '/Register', user, this.options)
      .subscribe((data: UserVM) =>
        alert('Successfull ' + data.username + ' registration!')
      );
  }

  Login(login: LoginVM): boolean {
    let error: boolean = true;
    this.http
      .post<LoginVM>(this.url + '/Login', login, this.options)
      .subscribe((data: any) => {
        if (data != null) {
          localStorage.setItem('authentication-token', data.value);
          this.router.navigateByUrl('Exhibitions');
        } else {
          localStorage.setItem('authentication-token', '');
        }
      });

    return error;
  }
}
