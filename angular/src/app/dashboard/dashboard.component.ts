import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'EgyptReciepts.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'EgyptReciepts.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
