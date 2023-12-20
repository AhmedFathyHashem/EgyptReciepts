import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44398/',
  redirectUri: baseUrl,
  clientId: 'EgyptReciepts_App',
  responseType: 'code',
  scope: 'offline_access EgyptReciepts',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'EgyptReciepts',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44398',
      rootNamespace: 'EgyptReciepts',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
