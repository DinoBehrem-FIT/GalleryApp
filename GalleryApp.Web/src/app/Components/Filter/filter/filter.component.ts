import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FilterVM } from 'src/app/ViewModels/Filter/FilterVM';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css'],
})
export class FilterComponent implements OnInit {
  params!: FormGroup;
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.params = this.formBuilder.group({
      creatorName: '',
      dateFrom: null,
      dateTo: null,
    });
  }
  @Output() filters = new EventEmitter<FilterVM>();

  sendFilters() {
    this.filters.emit(this.params.value as FilterVM);
  }
}
