import { LoginInfoVM } from './LoginInfoVM';

export class AuthHelper {
  static setLoginInfo(login: LoginInfoVM): void {
    if (login == null) {
      login = new LoginInfoVM();
    }
    localStorage.setItem('Authentication-token', JSON.stringify(login));
  }

  static getLoginInfo(): LoginInfoVM {
    let login = localStorage.getItem('Authentication-token');

    if (login === null) {
      return new LoginInfoVM();
    }

    try {
      let loginInfo: LoginInfoVM = JSON.parse(login);
      return loginInfo;
    } catch (err) {
      return new LoginInfoVM();
    }
  }
}
