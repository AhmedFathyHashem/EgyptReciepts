import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const BRANCHES_BRANCH_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/branches',
        iconClass: 'fas fa-hotel',
        name: '::Menu:Branches',
        layout: eLayoutType.application,
        //requiredPolicy: 'EgyptReciepts.Branches',
      },
    ]);
  };
}
