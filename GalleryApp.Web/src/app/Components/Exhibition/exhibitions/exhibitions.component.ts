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
  exhibitions: any = [];

  constructor(private exhibitionService: ExhibitionsService) {}

  ngOnInit(): void {
    this.exhibitionService
      .GetAllExhibitions()
      .subscribe((data: any) => (this.exhibitions = data));
  }
}
