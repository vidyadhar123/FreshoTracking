import { Component } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import * as XLSX from 'xlsx';
import { UploadService } from '../services/uploadService';

@Component({
    selector: 'app-upload-document',
    templateUrl: './upload-document.component.html'

})

export class UploadDocumentComponent {
    xml = `<note><to>User</to><from>Library</from><heading>Message</heading><body>Some XML to convert to JSON!</body></note>`;
    databseurl = '';
    customerReportsRequireFields = ['order_source', 'txn_id', 'date', 'first_name', 'last_name', 'total', 'fee', 'ship_date',
        , 'carrier', 'method', 'weight', 'tracking', 'postage', 'items', 'qtys', 'skus', 'subtotals'];
    constructor(private ngxXml2jsonService: NgxXml2jsonService, private uploadService: UploadService) {
    }


    numberOfInputs :number = 1;
    numberOfInputsArray:any[]= [1];


    // // file uploader for use to convert xml file to json
    // openXmlFile(fileupload) {
    //     const input = fileupload;
    //     for (var index = 0; index < input.files.length; index++) {
    //         const reader = new FileReader();
    //         reader.onload = () => {
    //             // this 'text' is the content of the file
    //             const text = reader.result;
    //         };
    //         reader.readAsText(input.files[index]);

    //     }
    //     const parser = new DOMParser();
    //     const xml = parser.parseFromString(this.xml, 'text/xml');
    //     const obj = this.ngxXml2jsonService.xmlToJson(xml);
    //     console.log(obj);
    // }


    // file uploader for use to convert xls file to json
    OpenXlsFile(ev) {
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
            const filterData = jsonData['customers_report (5)'].map(item => {
                return Object.assign({}, ...this.customerReportsRequireFields.map(key => ({ [key]: item[key] })));

            });
            this.uploadService.post(this.databseurl, filterData);
        };
        reader.readAsBinaryString(file);
    }
    // reader.readAsBinaryString(file);



    addInput(){
        debugger;
        this.numberOfInputs = this.numberOfInputs  + 1;
        this.numberOfInputsArray.push(this.numberOfInputs);
    }
}

