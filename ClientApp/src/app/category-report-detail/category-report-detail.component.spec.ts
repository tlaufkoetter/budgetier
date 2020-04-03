import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryReportDetailComponent } from './category-report-detail.component';

describe('CategoryReportDetailComponent', () => {
  let component: CategoryReportDetailComponent;
  let fixture: ComponentFixture<CategoryReportDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryReportDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryReportDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
