import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintByDocNumberComponent } from './print-by-doc-number.component';

describe('PrintByDocNumberComponent', () => {
  let component: PrintByDocNumberComponent;
  let fixture: ComponentFixture<PrintByDocNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintByDocNumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintByDocNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
