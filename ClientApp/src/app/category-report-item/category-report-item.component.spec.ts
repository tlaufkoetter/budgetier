import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryReportItemComponent } from './category-report-item.component';

describe('CategoryReportItemComponent', () => {
  let component: CategoryReportItemComponent;
  let fixture: ComponentFixture<CategoryReportItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryReportItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryReportItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
