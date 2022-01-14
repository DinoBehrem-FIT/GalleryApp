import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetExhibitionComponent } from './get-exhibition.component';

describe('GetExhibitionComponent', () => {
  let component: GetExhibitionComponent;
  let fixture: ComponentFixture<GetExhibitionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetExhibitionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetExhibitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
