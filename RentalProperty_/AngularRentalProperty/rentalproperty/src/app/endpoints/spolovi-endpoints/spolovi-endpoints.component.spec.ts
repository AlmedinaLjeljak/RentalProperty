import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpoloviEndpointsComponent } from './spolovi-endpoints.component';

describe('SpoloviEndpointsComponent', () => {
  let component: SpoloviEndpointsComponent;
  let fixture: ComponentFixture<SpoloviEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SpoloviEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpoloviEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
