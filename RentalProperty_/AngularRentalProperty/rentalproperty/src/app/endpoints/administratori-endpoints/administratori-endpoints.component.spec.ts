import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratoriEndpointsComponent } from './administratori-endpoints.component';

describe('AdministratoriEndpointsComponent', () => {
  let component: AdministratoriEndpointsComponent;
  let fixture: ComponentFixture<AdministratoriEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdministratoriEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdministratoriEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
