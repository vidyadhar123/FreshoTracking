import { Component } from '@angular/core';
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
    msg = '';
    formGroup: FormGroup;
    outputXml: any;
    inputXml: any;
    customerReportsRequireFields = ['order_source', 'txn_id', 'date', 'first_name', 'last_name', 'total', 'fee', 'ship_date',
        , 'carrier', 'method', 'weight', 'tracking', 'postage', 'items', 'qtys', 'skus', 'subtotals'];
    InvoiceList = ['Invoice Number', 'Invoice Date', 'Invoice Amount', 'PO Number', 'Check Number', 'Check Amount',
        'Check Date', 'Discount'];
    RemitList = ["balanceDue", "paymentDate", "checkNumber", "refInvoiceAmount", "refOrderNumber",
        "itemBalanceDue", "refInvoiceNumber", "refInvoiceDate", "refInvoiceDiscAmount", "refInvoiceAdjNumber"];
    filterData: any;


    IsSpinnerProgress: boolean = false;
    constructor(private ngxXml2jsonService: NgxXml2jsonService, private uploadService: UploadService, private _dateService: DateConverterService
    ) {
       
        // var original = [{ id: 1, value1: 500 }, { id: 1,value1:800, value2: 600 }, { id: 2, value1: 700 }, { id: 3, value2: 750 }],
        // template = { id: null, value1: null, value2: null },
        // result = Array.from(
        //     original
        //         .reduce(
        //             (m, o) => m.set(o.id, Object.assign({}, m.get(o.id) || template, o)),
        //             new Map
        //         )
        //         .values()
        // );
    
    // console.log(result);
        
    //     console.log(result);
    }


    OpenCustomReportXlsFile(ev) {
        debugger;
        this.msg = '';
        this.IsSpinnerProgress = false;
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
            debugger;
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
            })
            debugger;

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
            workBook = XLSX.read(data, { type: 'binary', cellDates: true });
            jsonData = workBook.SheetNames.reduce((initial, name) => {
                const sheet = workBook.Sheets[name];
                initial[name] = XLSX.utils.sheet_to_json(sheet, { dateNF: "MM-DD-YYYY" });
                return initial;
            }, {});
            debugger;
            this.filterData = jsonData['1'].map(item => {
                return Object.assign({}, ...this.InvoiceList.map(key => ({ [key]: item[key] })));
            });
            debugger;
            this.filterData.map((item, index) => {

                this.filterData[index]['Check Date'] = this._dateService.dateToString(item['Check Date']);
                this.filterData[index]['Invoice Date'] = this._dateService.dateToString(item['Invoice Date']);

            })

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

    // OpenRemitListXlsFile(ev) {

    //         const file1 = ev.target.files[0];
    //         if (!file1) {
    //             return;
    //         }
    //         const reader1 = new FileReader();
    //         reader1.onload = (evt) => {
    //             const xmlData: string = (evt as any).target.result;
    //            // JSON.parse(xml2json(xmlData,'  '))
    //             debugger;
    //         };
    //         reader1.readAsText(file1);

    //     debugger;
    //     this.msg = '';
    //     this.IsSpinnerProgress = false;
    //     let workBook = null;
    //     let jsonData = null;
    //     const reader = new FileReader();
    //     const file = ev.target.files[0];
    //     reader.onload = (event) => {
    //         const data = reader.result;
    //         workBook = XLSX.read(data, { type: 'binary' });
    //         jsonData = workBook.SheetNames.reduce((initial, name) => {
    //             const sheet = workBook.Sheets[name];
    //             initial[name] = XLSX.utils.sheet_to_json(sheet);
    //             return initial;
    //         }, {});
    //         jsonData
    //         debugger;

    //         this.filterData = jsonData['Sheet1'].map(item => {


    //             return Object.assign({}, ...this.RemitList.map(key => ({ [key]: item[key] })));
    //         });
    //         debugger;

    //         this.filterData.map((data,index)=> {
    //             this.filterData[index].paymentDate =  data.paymentDate.toString();
    //           if(data.refInvoiceDate !== undefined){
    //             this.filterData[index].refInvoiceDate = data.refInvoiceDate.toString();
    //           }else {
    //             this.filterData[index].refInvoiceDate  = '20200425'
    //           }


    //         })
    //         debugger;



    //         this.IsSpinnerProgress = true;

    //     };
    //     reader.readAsBinaryString(file);
    // }

    OpenRemitListXlsFile(event) {
        debugger
        const reader = new FileReader();
        reader.onload = (e: any) => {
            const xml = e.target.result;
            this.inputXml = xml;
            const parser = new DOMParser();
            const xml12 = parser.parseFromString(xml, 'text/xml');
            const JSONData = this.ngxXml2jsonService.xmlToJson(xml12);
            debugger;
            const RemittData = JSONData
            // console.log(this.objs);
            let outerData = RemittData['RemittanceAdvices']['RemittanceAdviceMessage'];
            const newArr1 =outerData.remittanceAdviceItem.map(v => ({...v,balanceDue:outerData.balanceDue,checkNumber:outerData.checkNumber,paymentDate:outerData.paymentDate }))
            // console.log('dsfdsffds', JSONData.RemittanceAdvices.RemittanceAdviceMessage.remittanceAdviceItem);
             this.filterData = newArr1.map(item => {
                 return Object.assign({}, ...this.RemitList.map(key => ({ [key]: item[key]})));
            });
            const data = JSON.stringify(this.filterData, function (key, value) {return (value === undefined) ? null : value});
             this.filterData = JSON.parse(data);
            debugger;
            // this.formGroup.patchValue(JSONData);
        };
        reader.readAsText(event.target.files[0]);
    }
  

    SaveRemitListInDatabase() {
        this.uploadService.insertRemitListRecord('https://localhost:44390/api/RemitList/InsertRemitList', this.filterData).
            subscribe(res =>
                this.insertRemitListRecordResponse(res), res => this.insertRemitListRecordError(res));
    }

    insertRemitListRecordResponse(res) {
        debugger;
        this.msg = 'document  uploaded sucessfully';
        this.IsSpinnerProgress = false;
        this.msg = '';
        this.msg = res.Message;
    }

    insertRemitListRecordError(res) { }

}

