import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadContributionPageComponent } from './upload-contribution-page.component';

describe('UploadContributionPageComponent', () => {
  let component: UploadContributionPageComponent;
  let fixture: ComponentFixture<UploadContributionPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UploadContributionPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UploadContributionPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
