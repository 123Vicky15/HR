import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PuestosverComponent } from './puestosver.component';

describe('PuestosverComponent', () => {
  let component: PuestosverComponent;
  let fixture: ComponentFixture<PuestosverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PuestosverComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PuestosverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
