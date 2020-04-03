import { TestBed } from '@angular/core/testing';

import { BudgetierApiService } from './budgetier-api.service';

describe('BudgetierApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BudgetierApiService = TestBed.get(BudgetierApiService);
    expect(service).toBeTruthy();
  });
});
