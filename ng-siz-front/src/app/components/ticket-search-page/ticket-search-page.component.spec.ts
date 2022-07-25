import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketSearchPageComponent } from './ticket-search-page.component';

describe('TicketSearchPageComponent', () => {
  let component: TicketSearchPageComponent;
  let fixture: ComponentFixture<TicketSearchPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketSearchPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketSearchPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
