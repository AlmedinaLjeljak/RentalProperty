import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikEndpointsComponent } from './korisnik-endpoints.component';

describe('KorisnikEndpointsComponent', () => {
  let component: KorisnikEndpointsComponent;
  let fixture: ComponentFixture<KorisnikEndpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KorisnikEndpointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KorisnikEndpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
