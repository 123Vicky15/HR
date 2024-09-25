import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExperienciaLaboralcrearComponent } from './experiencia-laboralcrear.component';

describe('ExperienciaLaboralcrearComponent', () => {
  let component: ExperienciaLaboralcrearComponent;
  let fixture: ComponentFixture<ExperienciaLaboralcrearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExperienciaLaboralcrearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExperienciaLaboralcrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
