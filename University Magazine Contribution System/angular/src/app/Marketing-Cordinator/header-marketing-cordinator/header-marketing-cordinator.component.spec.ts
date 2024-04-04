import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderMarketingCordinatorComponent } from './header-marketing-cordinator.component';

describe('HeaderMarketingCordinatorComponent', () => {
  let component: HeaderMarketingCordinatorComponent;
  let fixture: ComponentFixture<HeaderMarketingCordinatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HeaderMarketingCordinatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HeaderMarketingCordinatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
