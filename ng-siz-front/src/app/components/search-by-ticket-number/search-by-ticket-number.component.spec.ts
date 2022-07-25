import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchByTicketNumberComponent } from './search-by-ticket-number.component';

describe('SearchByTicketNumberComponent', () => {
  let component: SearchByTicketNumberComponent;
  let fixture: ComponentFixture<SearchByTicketNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchByTicketNumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchByTicketNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
