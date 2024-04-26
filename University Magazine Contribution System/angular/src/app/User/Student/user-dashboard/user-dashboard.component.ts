import { Component, OnInit } from '@angular/core';
import { DashboardDTO } from '../../../API/Admin/Dashboard/model';
import { DashboardService } from '../../../API/Admin/Dashboard/dasboard.service';
import { Chart, registerables } from 'chart.js';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.scss']
})
export class UserDashboardComponent implements OnInit {
  dashboardData: DashboardDTO;
  dashboardReport: DashboardDTO[] = [];
  barChart: Chart<'bar'>;
  pieChart: Chart<'pie'>;

  constructor(private dashboardService: DashboardService) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.fetchDashboardData();
    this.fetchDashboardReport();
  }

  fetchDashboardData(): void {
    this.dashboardService.getDashboardData().subscribe(
      (data: DashboardDTO) => {
        this.dashboardData = data;
        this.createBarChart();
        

      },
      (error) => {
        console.error('Failed to fetch dashboard data:', error);
      }
    );
  }
  fetchDashboardReport(): void {
    this.dashboardService.getDashboardReport().subscribe(
      (data: DashboardDTO[]) => {
        this.dashboardReport = data; // Assign the fetched data to dashboardReport
        this.createPieChart();
      },
      (error) => {
        console.error('Failed to fetch dashboard report:', error);
      }
    );
  }

  createBarChart(): void {
    const canvas = document.getElementById('worldwide-sales') as HTMLCanvasElement;
    const ctx = canvas.getContext('2d');
    
    if (ctx) {
      const labels = ['Total Contributions', 'Contribution of IT' ,'Contribution of Business' ];
      const values = [this.dashboardData.TotalContributions, this.dashboardData.NumOfC_InformationTechnology, this.dashboardData.NumOfC_Business];
      
      const data = {
        labels: labels.map((label, index) => `${label}: ${values[index]}`),
        datasets: [
          {
            label: 'Tổng số đóng góp',
            data: values,
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
          }
        ]
      };

      this.barChart = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
          scales: {
            y: {
              beginAtZero: true
            }
          }
        }
      });
    }
  }
  createPieChart(): void {
    const canvas = document.getElementById('salse-revenue') as HTMLCanvasElement;
    const ctx = canvas.getContext('2d');
  
    if (ctx) {
      const labels = this.dashboardReport.map((item) => item.facultyName);
      const values = this.dashboardReport.map((item) => item.percentageContributions);
  
      const chartData = {
        labels: labels,
        datasets: [
          {
            data: values,
            backgroundColor: [
              'rgba(75, 192, 192, 0.2)',
              'rgba(192, 75, 192, 0.2)',
              // Add more colors as needed
            ],
            borderColor: [
              'rgba(75, 192, 192, 1)',
              'rgba(192, 75, 192, 1)',
              // Add more colors as needed
            ],
            borderWidth: 1
          }
        ]
      };
  
      this.pieChart = new Chart(ctx, {
        type: 'pie',
        data: chartData,
        options: {
          responsive: true,
          maintainAspectRatio: false
        }
      });
    }
  }

  
}