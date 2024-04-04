import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContributionMarketingCordinatorComponent } from './contribution-marketing-cordinator.component';

describe('ContributionMarketingCordinatorComponent', () => {
  let component: ContributionMarketingCordinatorComponent;
  let fixture: ComponentFixture<ContributionMarketingCordinatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContributionMarketingCordinatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContributionMarketingCordinatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
