import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecenzijeEndpointsComponent } from './recenzije-endpoints.component';

describe('RecenzijeEndpointsComponent', () => {
  let component: RecenzijeEndpointsComponent;
  let fixture: ComponentFixture<RecenzijeEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecenzijeEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RecenzijeEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
