import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateContributionPageComponent } from './update-contribution-page.component';

describe('UpdateContributionPageComponent', () => {
  let component: UpdateContributionPageComponent;
  let fixture: ComponentFixture<UpdateContributionPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateContributionPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateContributionPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
