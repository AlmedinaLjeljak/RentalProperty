import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthEndpointsComponent } from './auth-endpoints.component';

describe('AuthEndpointsComponent', () => {
  let component: AuthEndpointsComponent;
  let fixture: ComponentFixture<AuthEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
