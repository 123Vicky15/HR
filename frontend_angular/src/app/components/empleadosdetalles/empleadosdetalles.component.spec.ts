import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadosdetallesComponent } from './empleadosdetalles.component';

describe('EmpleadosdetallesComponent', () => {
  let component: EmpleadosdetallesComponent;
  let fixture: ComponentFixture<EmpleadosdetallesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmpleadosdetallesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpleadosdetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
