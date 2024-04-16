import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllContributionComponent } from './view-all-contribution.component';

describe('ViewAllContributionComponent', () => {
  let component: ViewAllContributionComponent;
  let fixture: ComponentFixture<ViewAllContributionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ViewAllContributionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewAllContributionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
