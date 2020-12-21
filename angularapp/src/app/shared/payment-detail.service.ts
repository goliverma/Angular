import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import{ HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {

  constructor(private http : HttpClient) { }

  readonly baseUrl = 'http://localhost:5000/api/paymentdetail'

  formdata : PaymentDetail = new PaymentDetail();
  list : PaymentDetail[];

  postPaymentDetails(){
    return this.http.post(this.baseUrl, this.formdata);
  }

  putPaymentDetails(){
    return this.http.put(`${this.baseUrl}/${this.formdata.paymentDetailId}`, this.formdata);
  }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as PaymentDetail[]);
  }
}
