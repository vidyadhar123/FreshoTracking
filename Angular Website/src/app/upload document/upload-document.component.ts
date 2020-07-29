import { Component, ViewChild, ElementRef } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import * as XLSX from 'xlsx';
import { UploadService } from '../services/uploadService';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { DateConverterService } from '../services/dateconverter.service';
import * as converter from 'xml-js';
import { FormGroup } from '@angular/forms';
import { JsonPipe } from '@angular/common';




@Component({
    selector: 'app-upload-document',
    templateUrl: './upload-document.component.html'

})

export class UploadDocumentComponent {
    @ViewChild('customerfile') CutomerFile: ElementRef;
    @ViewChild('invoicefile') InvoiceFile: ElementRef;
    @ViewChild('remitfile') RemitFile: ElementRef;
    msg = '';
    formGroup: FormGroup;
    outputXml: any;
    inputXml: any;
    customerReportsRequireFields = ['order_source', 'txn_id', 'date', 'name', 'total', 'fee', 'ship_date',
        , 'carrier', 'method', 'weight', 'tracking', 'postage', 'item_name', 'quantity', 'subtotal', 'queue_id', 'item_description',
        , 'item_sku', 'line_number', 'location', 'num_order_lines',
        , 'payment_type', 'postage_account', 'shipping', 'status', 'tax', 'tnx_seq'];
    InvoiceList = ['Invoice Number', 'Invoice Date', 'Invoice Amount', 'PO Number', 'Check Number', 'Check Amount',
        'Check Date', 'Discount'];
    RemitList = ["balanceDue", "paymentDate",
        "checkNumber", "refInvoiceAmount", "refOrderNumber",
        "itemBalanceDue", "refInvoiceNumber",
        "refInvoiceDate", "refInvoiceDiscAmount", "refInvoiceAdjNumber"];
    filterData: any;
    IsSpinnerProgress: boolean = false;

    constructor(private ngxXml2jsonService: NgxXml2jsonService,
        private uploadService: UploadService,
        private _dateService: DateConverterService
    ) {

    }


    OpenCustomReportXlsFile(ev) {
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        const file = ev.target.files[0];
        reader.onload = (event) => {
            const data = reader.result;
            workBook = XLSX.read(data, { type: 'binary', cellDates: true });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet, { dateNF: "MM-DD-YYYY" });
                return initial;
            }, {});
            this.filterData = jsonData['Sheet1'].filter(x => x.order_source !== 'fba').map(item => {

                return Object.assign({}, ...this.customerReportsRequireFields.map(key => ({ [key]: item[key] })));
            });

            this.filterData.map((item, index) => {
                this.filterData[index].date = this._dateService.dateToString(item.date);
                this.filterData[index].ship_date = this._dateService.dateToString(item.ship_date);

                if ((item.txn_id.toString().indexOf('ch') !== -1) || (item.txn_id.toString().indexOf('wal') !== -1)) {
                    const dataindex = item.txn_id.toString().lastIndexOf('-');
                    this.filterData[index].txn_id = item.txn_id.slice(dataindex + 1)
                }
            });


            this.filterData;
            debugger;


            // this.msg = 'document  uploaded sucessfully';
        };
        reader.readAsBinaryString(file);
    }

    SaveCustomerRecordInDatabase() {
        debugger
        if (this.filterData !== undefined) {
            this.IsSpinnerProgress = true;
            this.uploadService.insertCustomerRecord('/api/CustomerReport/InsertCustomerReport', this.filterData)
                .subscribe(res =>
                    this.insertRecordResponse(res), res => this.insertRecordError(res));
        } else {
            this.msg = "Please Upload File"

        }
    }

    insertRecordResponse(res) {
        debugger
        this.IsSpinnerProgress = false;
        this.CutomerFile.nativeElement.value = '';
    }

    insertRecordError(res) {
        this.IsSpinnerProgress = false;
    }


    // file uploader for use to convert xls file to json in invoice list
    OpenInvoiceListXlsFile(ev) {
        // this.msg = '';
        let workBook = null;
        let jsonData = null;
        const reader = new FileReader();
        const file = ev.target.files[0];
        reader.onload = (event) => {
            const data = reader.result;
            workBook = XLSX.read(data, { type: 'binary', cellDates: true });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet, { dateNF: "MM-DD-YYYY" });
                return initial;
            }, {});
            this.filterData = jsonData['1'].map(item => {
                return Object.assign({}, ...this.InvoiceList.map(key => ({ [key]: item[key] })));
            });
            this.filterData.map((item, index) => {
                this.filterData[index]['Check Date'] = this._dateService.dateToString(item['Check Date']);
                this.filterData[index]['Invoice Date'] = this._dateService.dateToString(item['Invoice Date']);

            });
        };
        reader.readAsBinaryString(file);
    }

    SaveInvoiceListInDatabase() {
        if (this.filterData !== undefined) {
            this.IsSpinnerProgress = true;
            this.uploadService.insertInvoiceListRecord('/api/InvoiceList/InsertInvoiceListReport', this.filterData).
                subscribe(res =>
                    this.insertInvoiceListRecordResponse(res), res => this.insertInvoiceListRecordError(res));
        } else {
            this.msg = "Please Upload File"
        }
    }

    insertInvoiceListRecordResponse(res) {
        this.IsSpinnerProgress = false;
        this.InvoiceFile.nativeElement.value = '';
    }

    insertInvoiceListRecordError(res) {
        this.IsSpinnerProgress = false;
    }


    OpenRemitListXlsFile(event) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
            const xml = e.target.result;
            this.inputXml = xml;
            const parser = new DOMParser()    ;
            const xml12 = parser.parseFromString(xml, 'text/xml');
            const JSONData = this.ngxXml2jsonService.xmlToJson(xml12);
            const RemittData = JSONData;
            const outerData = RemittData['RemittanceAdvices']['RemittanceAdviceMessage'];
            const newArr1 = outerData.remittanceAdviceItem.
                map(v =>
                    ({ ...v, balanceDue: outerData.balanceDue, checkNumber: outerData.checkNumber, paymentDate: outerData.paymentDate }))
            this.filterData = newArr1.map(item => {
                return Object.assign({}, ...this.RemitList.map(key => ({ [key]: item[key] })));
            });
            const data = JSON.stringify(this.filterData, function (key, value) { return (value === undefined) ? null : value });
            
            this.filterData = JSON.parse(data);

            this.filterData.map((item, index)=> {
                this.filterData[index].refOrderNumber = this.filterData[index].refOrderNumber.replace(/^0+/, '');
            })

            this.filterData;
            debugger;



        };
        reader.readAsText(event.target.files[0]);
    }


    SaveRemitListInDatabase() {
        if (this.filterData !== undefined) {
            this.IsSpinnerProgress = true;
            this.uploadService.insertRemitListRecord('/api/RemitList/InsertRemitList', this.filterData).
                subscribe(res =>
                    this.insertRemitListRecordResponse(res), res => this.insertRemitListRecordError(res));
        } else {
            this.msg = "Please Upload File"
        }
    }

    insertRemitListRecordResponse(res) {
        this.IsSpinnerProgress = false;
        this.RemitFile.nativeElement.value = '';
    }

    insertRemitListRecordError(res) {
        this.IsSpinnerProgress = false;
    }

}

