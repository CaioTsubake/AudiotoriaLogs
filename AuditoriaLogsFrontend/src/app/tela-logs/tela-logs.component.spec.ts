import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaLogsComponent } from './tela-logs.component';

describe('TelaLogsComponent', () => {
  let component: TelaLogsComponent;
  let fixture: ComponentFixture<TelaLogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TelaLogsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TelaLogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
