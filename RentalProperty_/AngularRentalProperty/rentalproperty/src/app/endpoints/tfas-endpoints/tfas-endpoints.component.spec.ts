import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TfasEndpointsComponent } from './tfas-endpoints.component';

describe('TfasEndpointsComponent', () => {
  let component: TfasEndpointsComponent;
  let fixture: ComponentFixture<TfasEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TfasEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TfasEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
