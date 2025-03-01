import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FaqEndpointsComponent } from './faq-endpoints.component';

describe('FaqEndpointsComponent', () => {
  let component: FaqEndpointsComponent;
  let fixture: ComponentFixture<FaqEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FaqEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FaqEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
