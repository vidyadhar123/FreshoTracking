import { Component } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import * as XLSX from 'xlsx';
import { UploadService } from '../services/uploadService';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatProgressSpinner } from '@angular/material/progress-spinner';



@Component({
    selector: 'app-upload-document',
    templateUrl: './upload-document.component.html'

})

export class UploadDocumentComponent {
    msg = '';
    customerReportsRequireFields = ['order_source', 'txn_id', 'date', 'first_name', 'last_name', 'total', 'fee', 'ship_date',
        , 'carrier', 'method', 'weight', 'tracking', 'postage', 'items', 'qtys', 'skus', 'subtotals'];
    InvoiceList = ['Invoice Number', 'Invoice Date', 'Invoice Amount', 'PO Number', 'Check Number', 'Check Amount',
        'Check Date', 'Discount'];
    RemitList = ["balanceDue", "paymentDate", "checkNumber", "refInvoiceAmount", "refOrderNumber",
        "itemBalanceDue", "refInvoiceNumber", "refInvoiceDate", "refInvoiceDiscAmount", "refInvoiceAdjNumber"];
    filterData: any;
    IsSpinnerProgress: boolean = false;
    constructor(private ngxXml2jsonService: NgxXml2jsonService, private uploadService: UploadService,
    ) {
    }


    OpenCustomReportXlsFile(ev) {
        this.msg = '';
        this.IsSpinnerProgress = false;
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        const file = ev.target.files[0];
        reader.onload = (event) => {
            const data = reader.result;
            workBook = XLSX.read(data, { type: 'binary' });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet);
                return initial;
            }, {});
            this.filterData = jsonData['customers_report (5)'].filter(x => x.order_source !== 'fba').map(item => {
                return Object.assign({}, ...this.customerReportsRequireFields.map(key => ({ [key]: item[key] })));
            });
            this.msg = 'document  uploaded sucessfully';
            this.IsSpinnerProgress = true;

        };
        reader.readAsBinaryString(file);
    }


    // addInput() {
    //     this.numberOfInputs = this.numberOfInputs + 1;
    //     this.numberOfInputsArray.push(this.numberOfInputs);
    // }

    SaveCustomerRecordInDatabase() {
        this.uploadService.insertCustomerRecord('https://localhost:44390/api/CustomerReport/InsertCustomerReport', this.filterData)
            .subscribe(res =>
                this.insertRecordResponse(res), res => this.insertRecordError(res));
    }

    insertRecordResponse(res) {
        this.IsSpinnerProgress = false;
        this.msg = '';
        this.msg = res.Message;
    }

    insertRecordError(res) { }


    // file uploader for use to convert xls file to json in invoice list
    OpenInvoiceListXlsFile(ev) {
        debugger;
        this.msg = '';
        this.IsSpinnerProgress = false;
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        const file = ev.target.files[0];
        reader.onload = (event) => {
            const data = reader.result;
            workBook = XLSX.read(data, { type: 'binary' });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet);
                return initial;
            }, {});
            jsonData;
            debugger;
            this.filterData = jsonData['1'].map(item => {
                return Object.assign({}, ...this.InvoiceList.map(key => ({ [key]: item[key] })));
            });
            this.msg = 'document  uploaded sucessfully';
            this.IsSpinnerProgress = true;

        };
        reader.readAsBinaryString(file);
    }

    SaveInvoiceListInDatabase() {
        debugger;
        this.uploadService.insertInvoiceListRecord('https://localhost:44390/api/InvoiceList/InsertInvoiceListReport', this.filterData).
            subscribe(res =>
                this.insertInvoiceListRecordResponse(res), res => this.insertInvoiceListRecordError(res));
    }

    insertInvoiceListRecordResponse(res) {
        debugger;
        this.IsSpinnerProgress = false;
        this.msg = '';
        this.msg = res.Message;
        // if (res.statusCode === 200) {
        // } else {
        //     this.msg = res.Message;
        // }
    }

    insertInvoiceListRecordError(res) { }

    OpenRemitListXlsFile(ev) {
        debugger;
        this.msg = '';
        this.IsSpinnerProgress = false;
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        const file = ev.target.files[0];
        reader.onload = (event) => {
            const data = reader.result;
            workBook = XLSX.read(data, { type: 'binary' });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet);
                return initial;
            }, {});
            jsonData
            debugger;
            this.filterData = jsonData['Sheet1'].filter(x => x.order_source !== 'fba').map(item => {
                return Object.assign({}, ...this.RemitList.map(key => ({ [key]: item[key] })));
            });
            this.msg = 'document  uploaded sucessfully';
            this.IsSpinnerProgress = true;

        };
        reader.readAsBinaryString(file);
    }

    SaveRemitListInDatabase() {
        this.uploadService.insertRemitListRecord('https://localhost:44390/api/RemitList/InsertRemitList', this.filterData).
            subscribe(res =>
                this.insertRemitListRecordResponse(res), res => this.insertRemitListRecordError(res));
    }

    insertRemitListRecordResponse(res) {
        this.IsSpinnerProgress = false;
        this.msg = '';
        this.msg = res.Message;
    }

    insertRemitListRecordError(res) { }

}

