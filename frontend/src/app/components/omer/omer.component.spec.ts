import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OmerComponent } from './omer.component';

describe('OmerComponent', () => {
  let component: OmerComponent;
  let fixture: ComponentFixture<OmerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OmerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OmerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
