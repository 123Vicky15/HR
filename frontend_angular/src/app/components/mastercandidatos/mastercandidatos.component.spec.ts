import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MastercandidatosComponent } from './mastercandidatos.component';

describe('MastercandidatosComponent', () => {
  let component: MastercandidatosComponent;
  let fixture: ComponentFixture<MastercandidatosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MastercandidatosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MastercandidatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
