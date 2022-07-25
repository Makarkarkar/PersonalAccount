import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchByDocNumberComponent } from './search-by-doc-number.component';

describe('SearchByDocNumberComponent', () => {
  let component: SearchByDocNumberComponent;
  let fixture: ComponentFixture<SearchByDocNumberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchByDocNumberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchByDocNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
