import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdiomaseditarComponent } from './idiomaseditar.component';

describe('IdiomaseditarComponent', () => {
  let component: IdiomaseditarComponent;
  let fixture: ComponentFixture<IdiomaseditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdiomaseditarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IdiomaseditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
