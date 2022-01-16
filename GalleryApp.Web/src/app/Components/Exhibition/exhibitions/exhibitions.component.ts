import { Component, OnInit } from '@angular/core';
import { ExhibitionsService } from 'src/app/Services/Exhibition/exhibitions.service';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-exhibitions',
  templateUrl: './exhibitions.component.html',
  styleUrls: ['./exhibitions.component.css'],
})
export class ExhibitionsComponent implements OnInit {
  exhibitions: ExhibitionVM[] = [];
  imagePath: string = '../../../../../pexels.jpg';

  constructor(private exhibitionService: ExhibitionsService) {}

  ngOnInit(): void {
    this.exhibitionService
      .GetAll()
      .subscribe((data: any) => (this.exhibitions = data));
  }
}
