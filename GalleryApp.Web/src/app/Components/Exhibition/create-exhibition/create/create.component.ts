import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  ReactiveFormsModule,
  FormBuilder,
  FormControl,
} from '@angular/forms';
import { ExhibitionsService } from 'src/app/Services/Exhibition/exhibitions.service';
import { ExhibitionCreationVM } from 'src/app/ViewModels/Exhibition/ExhibitionCreationVM';

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
      title: '',
      description: '',
      startingDate: Date.now,
    });
  }

  create() {
    this.exhbitinioService.Create(
      this.exhibitionDetails.value as ExhibitionCreationVM
    );
  }
}
