import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingCordinatorPageComponent } from './marketing-cordinator-page.component';

describe('MarketingCordinatorPageComponent', () => {
  let component: MarketingCordinatorPageComponent;
  let fixture: ComponentFixture<MarketingCordinatorPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarketingCordinatorPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarketingCordinatorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
