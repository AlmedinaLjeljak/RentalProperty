import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradoviEndpointsComponent } from './gradovi-endpoints.component';

describe('GradoviEndpointsComponent', () => {
  let component: GradoviEndpointsComponent;
  let fixture: ComponentFixture<GradoviEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GradoviEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GradoviEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
