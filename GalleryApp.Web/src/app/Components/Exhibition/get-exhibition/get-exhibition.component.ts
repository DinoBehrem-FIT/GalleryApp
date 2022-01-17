import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExhibitionsService } from 'src/app/Services/Exhibition/exhibitions.service';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';

@Component({
  selector: 'app-get-exhibition',
  templateUrl: './get-exhibition.component.html',
  styleUrls: ['./get-exhibition.component.css'],
})
export class GetExhibitionComponent implements OnInit {
  exhibition!: ExhibitionVM;
  constructor(
    private exhibitionService: ExhibitionsService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.exhibitionService
      .GetSingle(this.activatedRoute.snapshot.paramMap.get('title') as string)
      .subscribe((data) => (this.exhibition = data));
  }
}
