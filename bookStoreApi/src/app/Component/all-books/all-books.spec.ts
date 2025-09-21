import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllBooks } from './all-books';

describe('AllBooks', () => {
  let component: AllBooks;
  let fixture: ComponentFixture<AllBooks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllBooks]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllBooks);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
