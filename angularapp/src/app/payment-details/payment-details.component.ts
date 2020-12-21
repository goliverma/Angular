import { Component, OnInit } from '@angular/core';
import { PaymentDetail } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: [
  ]
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public services : PaymentDetailService) { }

  ngOnInit(): void {
    this.services.refreshList();
  }
  populateForm(selectedRecord:PaymentDetail){
    this.services.formdata = Object.assign({}, selectedRecord);
  }

}
