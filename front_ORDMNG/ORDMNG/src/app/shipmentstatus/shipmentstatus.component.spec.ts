import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentstatusComponent } from './shipmentstatus.component';

describe('ShipmentstatusComponent', () => {
  let component: ShipmentstatusComponent;
  let fixture: ComponentFixture<ShipmentstatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipmentstatusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
