import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  ReactiveFormsModule,
  FormBuilder,
  FormControl,
} from '@angular/forms';
import { ExhibitionsService } from 'src/app/Services/Exhibition/exhibitions.service';
import { ExhibitionVM } from 'src/app/ViewModels/Exhibition/ExhibitionVM';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit {
  exhibitionDetails!: FormGroup;
  constructor(
    private exhbitinioService: ExhibitionsService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.exhibitionDetails = this.formBuilder.group({
      title: 'Title',
      description: 'Descritpion',
    });
  }

  create() {
    console.log(this.exhibitionDetails.value);

    this.exhbitinioService.Create(this.exhibitionDetails.value as ExhibitionVM);
  }
}
