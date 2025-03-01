import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrzaveEndpointsComponent } from './drzave-endpoints.component';

describe('DrzaveEndpointsComponent', () => {
  let component: DrzaveEndpointsComponent;
  let fixture: ComponentFixture<DrzaveEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DrzaveEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DrzaveEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
