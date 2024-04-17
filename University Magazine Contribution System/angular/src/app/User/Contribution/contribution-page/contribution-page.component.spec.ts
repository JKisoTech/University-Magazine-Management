import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContributionPageComponent } from './contribution-page.component';

describe('ContributionPageComponent', () => {
  let component: ContributionPageComponent;
  let fixture: ComponentFixture<ContributionPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContributionPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContributionPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
