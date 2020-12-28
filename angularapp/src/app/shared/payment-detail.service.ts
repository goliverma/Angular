import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {

  constructor(private http : HttpClient) { }

  readonly baseUrl = 'https://localhost:5001/api/paymentdetail'

  formdata : PaymentDetail = new PaymentDetail();
  list : PaymentDetail[];

  postPaymentDetails(){
    return this.http.post(this.baseUrl, this.formdata);
  }

  putPaymentDetails(){
    return this.http.put(`${this.baseUrl}/${this.formdata.paymentDetailId}`, this.formdata);
  }

  deletePaymentDetail(id : number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as PaymentDetail[]);
  }
}
