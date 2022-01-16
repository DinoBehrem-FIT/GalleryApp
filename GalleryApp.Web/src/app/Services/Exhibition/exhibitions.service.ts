import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';

@Injectable({
  providedIn: 'root',
})
export class ExhibitionsService {
  url: string = 'https://localhost:44355/Exhibition';
  options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  constructor(private http: HttpClient) {}

  GetAll(): Observable<ExhibitionVM[]> {
    return this.http.get<ExhibitionVM[]>(this.url + '/Index');
  }

  Create(exhibition: ExhibitionVM): any {
    return this.http
      .post<ExhibitionVM>(
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
