import type { BranchCreateDto, BranchDto, BranchExcelDownloadDto, BranchUpdateDto, GetBranchesInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class BranchService {
  apiName = 'Default';
  

  create = (input: BranchCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BranchDto>({
      method: 'POST',
      url: '/api/app/branches',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/branches/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BranchDto>({
      method: 'GET',
      url: `/api/app/branches/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/branches/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetBranchesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BranchDto>>({
      method: 'GET',
      url: '/api/app/branches',
      params: { filterText: input.filterText, title: input.title, mangerName: input.mangerName, startTimeMin: input.startTimeMin, startTimeMax: input.startTimeMax, endTimeMin: input.endTimeMin, endTimeMax: input.endTimeMax, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: BranchExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/branches/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, title: input.title, mangerName: input.mangerName, startTimeMin: input.startTimeMin, startTimeMax: input.startTimeMax, endTimeMin: input.endTimeMin, endTimeMax: input.endTimeMax },
    },
    { apiName: this.apiName,...config });
  

  update = (id: number, input: BranchUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BranchDto>({
      method: 'PUT',
      url: `/api/app/branches/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
