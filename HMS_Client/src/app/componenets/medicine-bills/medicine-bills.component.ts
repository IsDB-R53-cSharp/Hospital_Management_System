import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MedicineBills } from '../../models/medicine-bills';
import { MedicineBillsService } from '../../service/medicine-bills.service'; // Import the service

@Component({
  selector: 'app-medicine-bills',
  templateUrl: './medicine-bills.component.html',
  styleUrls: ['./medicine-bills.component.css']
})
export class MedicineBillsComponent implements OnInit {
  MedicineBills: MedicineBills[] = [];
  PostMedicineBills: MedicineBills = {
    medicineBillId: undefined,
    medicineName: '',
    prescriptionID: undefined,
    medicineCount: 0,
    price: 0,
    netPrice: 0,
    isComplete: true,
    paidAmount: 0,
    due: 0
  };

  constructor(private medicineBillsService: MedicineBillsService, private router: Router) { }

  ngOnInit() {
    this.getAllMedicineBills();
  }

  getAllMedicineBills() {
    this.medicineBillsService.GetAllMedicineBills().subscribe(data => {
      this.MedicineBills = data;
    });
  }



  insertMedicineBills() {
    if (this.PostMedicineBills.medicineBillId === undefined) {
      // Ensure that the properties are numeric values
      if (
        typeof this.PostMedicineBills.medicineCount === 'number' &&
        typeof this.PostMedicineBills.price === 'number' &&
        typeof this.PostMedicineBills.paidAmount === 'number'
      ) {
        // Calculate netPrice
        this.PostMedicineBills.netPrice = this.PostMedicineBills.medicineCount * this.PostMedicineBills.price;

        // Calculate due
        this.PostMedicineBills.due = this.PostMedicineBills.netPrice - this.PostMedicineBills.paidAmount;

        if (this.PostMedicineBills.medicineBillId === undefined) {
          this.medicineBillsService.PostMedicineBills(this.PostMedicineBills).subscribe(p => {
            console.log(p);

            // After posting, update the list of medicine bills
            this.getAllMedicineBills();

            // Reset the PostMedicineBills object
            this.PostMedicineBills = {
              medicineBillId: undefined,
              medicineName: '',
              prescriptionID: undefined,
              medicineCount: 0,
              price: 0,
              netPrice: 0,
              isComplete: true,
              paidAmount: 0,
              due: 0
            };
          });
        }
      } else {
        // Handle the case where one or more of the numeric properties are not valid (e.g., display an error message)
        console.error('Invalid numeric values for calculations.');


      }
    }
    this.UpdateMedicineBills(this.PostMedicineBills)
    this.PostMedicineBills = {
      medicineBillId: undefined,
      medicineName: '',
      prescriptionID: undefined,
      medicineCount: 0,
      price: 0,
      netPrice: 0,
      isComplete: true,
      paidAmount: 0,
      due: 0
    }
  }

  UpdateMedicineBills(PostMedicineBills: MedicineBills) {
    this.medicineBillsService.UpdateMedicineBills(PostMedicineBills).subscribe(up => {
      this.getAllMedicineBills();
    });
  }
  PopulateMedicineBills(POP: MedicineBills) {
    this.PostMedicineBills = POP
  }

}
