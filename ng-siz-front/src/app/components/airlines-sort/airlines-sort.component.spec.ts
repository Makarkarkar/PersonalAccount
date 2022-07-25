import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirlinesSortComponent } from './airlines-sort.component';

describe('AirlinesSortComponent', () => {
  let component: AirlinesSortComponent;
  let fixture: ComponentFixture<AirlinesSortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AirlinesSortComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AirlinesSortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
