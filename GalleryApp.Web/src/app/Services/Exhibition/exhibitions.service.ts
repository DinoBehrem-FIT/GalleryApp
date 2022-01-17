import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';
import { ExhibitionCreationVM } from 'src/app/ViewModels/Exhibition/ExhibitionCreationVM';

@Injectable({
  providedIn: 'root',
})
export class ExhibitionsService {
  url: string = 'https://localhost:44355/Exhibition';
  authToken = '' + localStorage.getItem('authentication-token')?.toString();
  options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'authentication-token': this.authToken,
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
}
