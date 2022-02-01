import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthTokenVM } from 'src/app/ViewModels/Authorization/AuthTokenVM';
import { AuthHelper } from 'src/app/ViewModels/Helpers/AuthenticationHelper';
import { LoginVM } from 'src/app/ViewModels/User/LoginVM';
import { RegistrationVM } from 'src/app/ViewModels/User/RegistrationVM';
import { UserVM } from 'src/app/ViewModels/User/UserVM';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  url: string = 'https://localhost:44355/Authentication';

  getToken(): string {
    let authentication_token: AuthTokenVM =
      AuthHelper.getLoginInfo().authentication_token;
    let myToken: string = '';

    if (authentication_token != null) {
      myToken = authentication_token.value;
    }

    return myToken;
  }

  options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authentication-token': this.getToken(),
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
    this.http
      .post<LoginVM>(this.url + '/Login', login, this.options)
      .subscribe((data: any) => {
        if (data != null) {
          AuthHelper.setLoginInfo(data);
          this.router.navigateByUrl('Exhibitions');
        } else {
          localStorage.removeItem('Authentication-token');
        }
      });
    return false;
  }
}
