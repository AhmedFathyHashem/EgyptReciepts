import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface BranchCreateDto {
  title: string;
  mangerName: string;
  startTime?: string;
  endTime?: string;
}

export interface BranchDto extends FullAuditedEntityDto<number> {
  title?: string;
  mangerName?: string;
  startTime?: string;
  endTime?: string;
  concurrencyStamp?: string;
}

export interface BranchExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  title?: string;
  mangerName?: string;
  startTimeMin?: string;
  startTimeMax?: string;
  endTimeMin?: string;
  endTimeMax?: string;
}

export interface BranchUpdateDto {
  title: string;
  mangerName: string;
  startTime?: string;
  endTime?: string;
  concurrencyStamp?: string;
}

export interface GetBranchesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  title?: string;
  mangerName?: string;
  startTimeMin?: string;
  startTimeMax?: string;
  endTimeMin?: string;
  endTimeMax?: string;
}
