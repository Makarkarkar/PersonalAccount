import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintByTicketNumberComponent } from './print-by-ticket-number.component';

describe('PrintByTicketNumberComponent', () => {
  let component: PrintByTicketNumberComponent;
  let fixture: ComponentFixture<PrintByTicketNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintByTicketNumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintByTicketNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
