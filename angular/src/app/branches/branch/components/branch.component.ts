import { ABP, downloadBlob, ListService, PagedResultDto, PermissionService, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetBranchesInput, BranchDto } from '../../../proxy/branches/models';
import { BranchService } from '../../../proxy/branches/branch.service';
@Component({
  selector: 'app-branch',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './branch.component.html',
  styles: [],
})
export class BranchComponent implements OnInit {
  data: PagedResultDto<BranchDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetBranchesInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  startTimeSpan: string;

  endTimeSpan: string;

  selected?: BranchDto;

  isPublic = false;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: BranchService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder,
    private permissionService: PermissionService
  ) { }

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });
    this.isPublic = !this.permissionService.getGrantedPolicy('EgyptReciepts.Branches.Default');
    const setData = (list: PagedResultDto<BranchDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetBranchesInput;
  }

  buildForm() {
    const { title, mangerName, startTime, endTime } = this.selected || {};

    this.form = this.fb.group({
      title: [title ?? null, [Validators.required, Validators.maxLength(200)]],
      mangerName: [mangerName ?? null, [Validators.required, Validators.maxLength(250)]],
      startTime: [startTime ?? null, [Validators.required]],
      endTime: [endTime ?? null, [Validators.required]],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;
    const selectedStartTime = this.form.value.startTime;
    const selectedEndTime = this.form.value.endTime;

    const startDate = new Date();    
    startDate.setHours(selectedStartTime.hour);
    startDate.setMinutes(selectedStartTime.minute);
    startDate.toUTCString()

    const endDate = new Date();        
    endDate.setHours(selectedEndTime.hour);
    endDate.setMinutes(selectedEndTime.minute);


    this.form.value.startTime = startDate;
    this.form.value.endTime = endDate;
    const request = this.selected
      ? this.service.update(this.selected.id, {
        ...this.form.value,
        concurrencyStamp: this.selected.concurrencyStamp,
      })
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: BranchDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: BranchDto) {
    this.confirmation
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }

  Book(record: BranchDto) {
    const options: Partial<Confirmation.Options> = {
      hideCancelBtn: true,
      hideYesBtn: true,
      messageLocalizationParams: [record.title],
      dismissible: true,
    }
    this.confirmation
      .success('::BookingConfimationMessage', '::BookingSuccess', options)

  }

  exportToExcel() {
    this.isExportToExcelBusy = true;
    this.service
      .getDownloadToken()
      .pipe(
        switchMap(({ token }) =>
          this.service.getListAsExcelFile({ downloadToken: token, filterText: this.list.filter })
        ),
        finalize(() => (this.isExportToExcelBusy = false))
      )
      .subscribe(result => {
        downloadBlob(result, 'Branch.xlsx');
      });
  }
}
