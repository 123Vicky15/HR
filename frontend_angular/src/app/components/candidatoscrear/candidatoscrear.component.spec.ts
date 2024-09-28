import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatoscrearComponent } from './candidatoscrear.component';

describe('CandidatoscrearComponent', () => {
  let component: CandidatoscrearComponent;
  let fixture: ComponentFixture<CandidatoscrearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CandidatoscrearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CandidatoscrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
