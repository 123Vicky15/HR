import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetenciasformcrearComponent } from './competenciasformcrear.component';

describe('CompetenciasformcrearComponent', () => {
  let component: CompetenciasformcrearComponent;
  let fixture: ComponentFixture<CompetenciasformcrearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompetenciasformcrearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompetenciasformcrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
