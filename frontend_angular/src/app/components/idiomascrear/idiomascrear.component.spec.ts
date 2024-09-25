import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdiomascrearComponent } from './idiomascrear.component';

describe('IdiomascrearComponent', () => {
  let component: IdiomascrearComponent;
  let fixture: ComponentFixture<IdiomascrearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdiomascrearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IdiomascrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
