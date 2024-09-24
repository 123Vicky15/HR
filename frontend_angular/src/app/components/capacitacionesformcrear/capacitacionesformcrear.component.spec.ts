import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CapacitacionesformcrearComponent } from './capacitacionesformcrear.component';

describe('CapacitacionesformcrearComponent', () => {
  let component: CapacitacionesformcrearComponent;
  let fixture: ComponentFixture<CapacitacionesformcrearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CapacitacionesformcrearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CapacitacionesformcrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
