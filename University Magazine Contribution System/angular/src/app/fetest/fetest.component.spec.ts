import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetestComponent } from './fetest.component';

describe('FetestComponent', () => {
  let component: FetestComponent;
  let fixture: ComponentFixture<FetestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FetestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FetestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
