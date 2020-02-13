import { Component } from '@angular/core';
import { NgxXml2jsonService } from 'ngx-xml2json';
import * as XLSX from 'xlsx';

@Component({
    selector: 'app-upload-document',
    templateUrl: './upload-document.component.html'

})

export class UploadDocumentComponent {
    xml = `<note><to>User</to><from>Library</from><heading>Message</heading><body>Some XML to convert to JSON!</body></note>`;
    constructor(private ngxXml2jsonService: NgxXml2jsonService) {
    }


    // file uploader for use to convert xml file to json
    openXmlFile(fileupload) {
        debugger
        const input = fileupload;
        for (var index = 0; index < input.files.length; index++) {
            const reader = new FileReader();
            reader.onload = () => {
                // this 'text' is the content of the file
                const text = reader.result;
            };
            reader.readAsText(input.files[index]);

        }
        const parser = new DOMParser();
        const xml = parser.parseFromString(this.xml, 'text/xml');
        const obj = this.ngxXml2jsonService.xmlToJson(xml);
        console.log(obj);
    }


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
            console.log(jsonData);

        };
        reader.readAsBinaryString(file);
    }
    // reader.readAsBinaryString(file);
}

