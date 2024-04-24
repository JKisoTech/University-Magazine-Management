import { Component, OnInit } from '@angular/core';
import { ContributionDto } from '../../API/Admin/Contribution/model';
import { ContributionService } from '../../API/Admin/Contribution/contribution.service';

@Component({
  selector: 'app-documents-management',
  templateUrl: './documents-management.component.html',
  styleUrl: './documents-management.component.scss'
})
export class DocumentsManagementComponent implements OnInit {

  pageSize = 5;
  contribution: ContributionDto[] = [];
  currentPage = 1;
  paginatedContribution: ContributionDto[] = [];

  constructor(
    private contributionService : ContributionService,
  ){}

  ngOnInit(): void {
    this.contributionService.GetContributor().subscribe((result) => {
      this.contribution = result;
      this.paginateContribution();
    });
  }

  paginateContribution(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedContribution = this.contribution.slice(startIndex, endIndex);
  }
  setCurrentPage(page: number): void {
    this.currentPage = page;
    this.paginateContribution();
  }

  getPageNumbers(): number[] {
    const totalPages = Math.ceil(this.contribution.length / this.pageSize);
    return Array.from({ length: totalPages }, (_, i) => i + 1);
  }

  hasNextPage(): boolean {
    const totalPages = Math.ceil(this.contribution.length / this.pageSize);
    return totalPages > 1;
  }
  getStatusText(status: number | undefined): string {
    if (typeof status === 'undefined') {
      return '';
    }
  
    switch (status) {
      case 0:
        return 'Unpublic';
      case 1:
        return 'Updated';
      case 2:
        return 'Public by Student';
      case 3:
        return 'Approve by Cordinator';
      default:
        return '';
    }
  }

}
