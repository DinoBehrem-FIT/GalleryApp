import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';
import { ExhibitionCreationVM } from 'src/app/ViewModels/Exhibition/ExhibitionCreationVM';
import { FilterVM } from 'src/app/ViewModels/Filter/FilterVM';
import { AuthTokenVM } from 'src/app/ViewModels/Authorization/AuthTokenVM';
import { AuthHelper } from 'src/app/ViewModels/Helpers/AuthenticationHelper';

@Injectable({
  providedIn: 'root',
})
export class ExhibitionsService {
  url: string = 'https://localhost:44355/Exhibition';
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

  constructor(private http: HttpClient) {}

  GetAll(): Observable<ExhibitionVM[]> {
    return this.http.get<ExhibitionVM[]>(this.url + '/Index', this.options);
  }

  GetSingle(title: string): Observable<ExhibitionVM> {
    return this.http.get<ExhibitionVM>(this.url + '/GetByTitle?title=' + title);
  }

  Create(exhibition: ExhibitionCreationVM): any {
    return this.http
      .post<ExhibitionCreationVM>(
        this.url + '/CreateExhibition',
        exhibition,
        this.options
      )
      .subscribe((data: any) =>
        alert(
          'Exhibition ' + '"' + data.title + '"' + ' successfully organized!'
        )
      );
  }

  Filter(filter: FilterVM): Observable<ExhibitionVM[]> {
    let dateFromString: string;
    let dateToString: string;

    if (filter.dateFrom == null) {
      filter.dateFrom = new Date(new Date().toLocaleDateString());

      dateFromString = this.getDateTimeString(filter.dateFrom);
    } else {
      dateFromString = filter.dateFrom.toString();
    }

    if (filter.dateTo == null) {
      filter.dateTo = new Date(new Date(2050, 1, 1).toLocaleDateString());

      dateToString = this.getDateTimeString(filter.dateTo);
    } else {
      dateToString = filter.dateTo.toString();
    }

    console.log(dateFromString + ' ------------ ' + dateToString);

    const httpParams = new HttpParams({
      fromObject: {
        creatorName: filter.creatorName,
        dateFrom: dateFromString,
        dateTo: dateToString,
      },
    });

    console.log(httpParams);

    return this.http.get<ExhibitionVM[]>(this.url + '/GetByFilter', {
      params: httpParams,
    });
  }

  getDateTimeString(dateTime: Date): string {
    let dateString: string;

    dateTime = new Date(new Date(2050, 1, 1).toLocaleDateString());
    dateString = dateTime.getFullYear().toString() + '-';

    if (dateTime.getMonth() < 9) {
      dateString += '0' + (dateTime.getMonth() + 1).toString() + '-';
    } else {
      dateString +=
        (dateTime.getMonth() + 1).toString() +
        '-' +
        dateTime.getDate().toString();
    }

    if (dateTime.getDate() < 10) {
      dateString += '0' + dateTime.getDate().toString();
    } else {
      dateString += dateTime.getDate().toString();
    }

    if (dateTime.getHours() < 10) {
      dateString += 'T0' + dateTime.getHours().toString() + ':';
    } else {
      dateString += dateTime.getHours().toString();
    }

    if (dateTime.getMinutes() < 10) {
      dateString += '0' + dateTime.getMinutes().toString();
    } else {
      dateString += dateTime.getMinutes().toString();
    }

    return dateString;
  }
}
