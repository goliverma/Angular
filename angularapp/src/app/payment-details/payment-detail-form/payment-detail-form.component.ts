import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styles: [
  ]
})
export class PaymentDetailFormComponent implements OnInit {

  constructor(public services : PaymentDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  onSubmit(form : NgForm){
    if(this.services.formdata.paymentDetailId == 0)
    this.insertForm(form);
    else
    this.updateForm(form);
  }

  insertForm(form : NgForm){
    this.services.postPaymentDetails().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted Successfully','Payment Detail Register');
        this.services.refreshList();
      },
      err => { console.log(err); }
    );
  }

  updateForm(form : NgForm){
    this.services.putPaymentDetails().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Updated Successfully','Payment Detail Register');
        this.services.refreshList();
      },
      err => { console.log(err); }
    );
  }

  resetForm(form : NgForm){
    form.form.reset();
    this.services.formdata = new PaymentDetail();
  }
}
