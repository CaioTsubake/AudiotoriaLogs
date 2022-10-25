import { TestBed } from '@angular/core/testing';

import { TelaLogsService } from './tela-logs.service';

describe('TelaLogsService', () => {
  let service: TelaLogsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TelaLogsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
