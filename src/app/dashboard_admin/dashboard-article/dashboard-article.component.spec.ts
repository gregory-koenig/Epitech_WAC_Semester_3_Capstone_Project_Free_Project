import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardArticleComponent } from './dashboard-article.component';

describe('DashboardArticleComponent', () => {
  let component: DashboardArticleComponent;
  let fixture: ComponentFixture<DashboardArticleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardArticleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
