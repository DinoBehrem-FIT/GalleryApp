import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';

@Injectable({
  providedIn: 'root',
})
export class ExhibitionsService {
  url: string = 'https://localhost:44355/Exhibition';

  constructor(private http: HttpClient) {}

  GetAllExhibitions(): any {
    return this.http.get(this.url + '/Index');
  }
}
