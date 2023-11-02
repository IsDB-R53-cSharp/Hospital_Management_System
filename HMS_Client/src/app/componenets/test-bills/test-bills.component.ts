import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestBills } from '../../models/test-bills';

import { TestBillsService } from '../../service/test-bills.service';

@Component({
  selector: 'app-test-bills',
  templateUrl: './test-bills.component.html',
  styleUrls: ['./test-bills.component.css']
})
export class TestBillsComponent implements OnInit {
  TestBills: TestBills[] = [];
  PostTestBill: TestBills = {
    testBillId: undefined,
    testBillName: '',
    prescriptionID: undefined,
    price: 0,
    isComplete: true,
    paidAmount: 0,
    due: 0 // Initialize due to 0
  };

  constructor(private testBillsService: TestBillsService, private router: Router) { }

  ngOnInit() {
    this.getAllTestBills();
  }

  getAllTestBills() {
    this.testBillsService.GetAllTestBills().subscribe(data => {
      this.TestBills = data;
    });
  }

  calculateDue() {
    // Ensure that the price and paidAmount properties are numbers before performing calculations
    if (typeof this.PostTestBill.price === 'number' && typeof this.PostTestBill.paidAmount === 'number') {
      this.PostTestBill.due = this.PostTestBill.price - this.PostTestBill.paidAmount;
    } else {
      // Handle the case where price or paidAmount is not a number (e.g., show an error message)
      console.error('Price and paidAmount must be numeric values');
    }
  }

  postTestBills() {
    if (this.PostTestBill.testBillId === undefined) {
      // Calculate the due before posting
      this.calculateDue();

      // Post the data to the service
      this.testBillsService.PostTestBills(this.PostTestBill).subscribe(data => {
        this.TestBills.push(data);

        // Reset the form
        this.PostTestBill = {
          testBillId: undefined,
          testBillName: '',
          prescriptionID: undefined,
          price: 0,
          isComplete: true,
          paidAmount: 0,
          due: 0 // Reset due to 0
        };
      });
    }
    else {
      this.UpdateTestBills(this.PostTestBill)
      this.PostTestBill = {
        testBillId: undefined,
        testBillName: '',
        prescriptionID: undefined,
        price: 0,
        isComplete: true,
        paidAmount: 0,
        due: 0
      }
    }
  }


  UpdateTestBills(PostTestBill: TestBills) {
    this.testBillsService.UpdateTestBills(PostTestBill).subscribe(up => {
      this.getAllTestBills();
    });
  }
  PopulateTestBills(POP: TestBills) {
    this.PostTestBill = POP
  }
}




//import { Component, OnInit } from '@angular/core';
//import { Router } from '@angular/router';
//import { TestBills } from '../../models/test-bills';
//import { TestBillsService } from '../../service/test-bills.service';

//@Component({
//  selector: 'app-test-bills',
//  templateUrl: './test-bills.component.html',
//  styleUrls: ['./test-bills.component.css']
//})
//export class TestBillsComponent implements OnInit {
//  TestBills: TestBills[] = [];
//  PostTakenService: TestBills = {
//    testBillId: undefined,
//    testBillName: '',
//    PrescriptionID: undefined,
//    price: 0,
//    isComplete: true,
//    paidAmount: 0,
//    due: 0
//  };

//  constructor(private testBillsService: TestBillsService, private router: Router) { }

//  ngOnInit() {
//    this.getAllTestBills();
//  }

//  getAllTestBills() {
//    this.testBillsService.GetAllTestBills().subscribe(data => {
//      this.TestBills = data;
//    });
//  }
//  postTestBills() {
//    // Calculate the due before posting
//    this.calculateDue();

//    // Post the data to the service
//    this.testBillsService.postTestBills(this.PostTakenService).subscribe(data => {
//      this.TestBills.push(data);

//      // Reset the form
//      this.PostTakenService = {
//        testBillId: undefined,
//        testBillName: '',
//        PrescriptionID: undefined,
//        price: 0,
//        isComplete: true,
//        paidAmount: 0,
//        due: 0
//      };
//    });
//  }



//}
