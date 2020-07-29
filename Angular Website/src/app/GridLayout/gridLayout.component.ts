import { Component, ViewChild } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { Observable, of } from 'rxjs';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { UploadService } from '../services/uploadService';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'table-expandable-rows-example',
  templateUrl: 'gridLayout.component.html',
  styleUrls:['gridLayout.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class GridLayoutComponent {
  IsSpinnerProgress;
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  columnsToDisplay= ["txnId","date","customerName","totalQtyShipped","totalInvoiced","checkNumber"]
  // dataSource = new ExampleDataSource();
  // data;
  constructor(private uploadService:UploadService){

  }

  isExpansionDetailRow = (i: number, row: Object) => row.hasOwnProperty('detailRow');
  expandedElement: any;

  ngOnInit(){
    this.IsSpinnerProgress = true;
    this.uploadService.getCustomerRecord('https://localhost:44390/api/CustomerReport/GetUsersDetails')
    .subscribe(res =>
        this.insertRecordResponse(res), res => this.insertRecordError(res));

  }

  insertRecordResponse(res) {
    debugger;
    this.IsSpinnerProgress = false;
    const data = JSON.stringify(res, function (key, value) { return (value === null) ? undefined : value });
            
    const gridData= JSON.parse(data);

    const finalData = this.mergeObjectsInUnique(gridData,'txnId')
   
    debugger;
    
    this.dataSource = new MatTableDataSource(finalData);
     this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    //this.IsSpinnerProgress = false;
  //  this.CutomerFile.nativeElement.value = '';
}

  mergeObjectsInUnique<T>(array: T[], property: any): T[] {

  const newArray = new Map();

  array.forEach((item: T) => {
    const propertyValue = item[property];
    newArray.has(propertyValue) ? newArray.set(propertyValue, { ...item, ...newArray.get(propertyValue) }) : newArray.set(propertyValue, item);
  });

  return Array.from(newArray.values());
}

ngAfterViewInit() {
 
}

applyFilter(filterValue: string) {
  filterValue = filterValue.trim(); // Remove whitespace
  filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
  this.dataSource.filter = filterValue;
}


insertRecordError(res) {
    //this.IsSpinnerProgress = false;
}
};


