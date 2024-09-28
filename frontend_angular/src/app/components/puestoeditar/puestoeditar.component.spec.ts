import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PuestoeditarComponent } from './puestoeditar.component';

describe('PuestoeditarComponent', () => {
  let component: PuestoeditarComponent;
  let fixture: ComponentFixture<PuestoeditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PuestoeditarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PuestoeditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
