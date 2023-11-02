import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TakenServices } from '../../models/taken-services';
import { TakenServicesService } from '../../service/taken-services.service';

@Component({
  selector: 'app-taken-services',
  templateUrl: './taken-services.component.html',
  styleUrls: ['./taken-services.component.css']
})

export class TakenServicesComponent implements OnInit {
  TakenServices: TakenServices[] = [];
  PostTakenService: TakenServices = {
    takenServiceId: undefined,
    takenServiceName: '',
    date: new Date(),
    patientID: undefined,
    price: 0,
    isComplete: true,
    paidAmount: 0,
    due: 0
  };

  constructor(private takenServicesService: TakenServicesService, private router: Router) { }

  ngOnInit() {
    this.getAllTakenServices();
  }

  getAllTakenServices() {
    this.takenServicesService.GetAllTakenServices().subscribe(data => {
      this.TakenServices = data;
    });
  }

  calculateDue() {
    // Ensure that the price and paidAmount properties are numbers before performing calculations
    if (typeof this.PostTakenService.price === 'number' && typeof this.PostTakenService.paidAmount === 'number') {
      this.PostTakenService.due = this.PostTakenService.price - this.PostTakenService.paidAmount;
    } else {
      // Handle the case where price or paidAmount is not a number (e.g., show an error message)
      console.error('Price and paidAmount must be numeric values');
    }
  }
  calculateSubtotalPriceAmount(): number {
    return this.TakenServices.reduce((total, service) => total + (service.price || 0), 0);
  }

  calculateSubtotalPaidAmount(): number {
    return this.TakenServices.reduce((total, service) => total + (service.paidAmount || 0), 0);
  }

  calculateSubtotalDue(): number {
    return this.TakenServices.reduce((total, service) => total + (service.due || 0), 0);
  }



  postTakenService() {

    if (this.PostTakenService.takenServiceId === undefined) {
      // Calculate the due before posting
      this.calculateDue();


      // Post the data to the service
      this.takenServicesService.PostTakenServices(this.PostTakenService).subscribe(data => {
        this.TakenServices.push(data);

        // Reset the form
        this.PostTakenService = {
          takenServiceId: undefined,
          takenServiceName: '',
          date: new Date(),
          patientID: undefined,
          price: 0,
          isComplete: true,
          paidAmount: 0,
          due: 0
        };
      });

    }
    else {
      this.UpdateTakenServices(this.PostTakenService)
      this.PostTakenService = {
        takenServiceId: undefined,
        takenServiceName: '',
        date: new Date(),
        patientID: undefined,
        price: 0,
        isComplete: true,
        paidAmount: 0,
        due: 0
      }
    }
  }


  UpdateTakenServices(PostTakenService: TakenServices) {
    this.takenServicesService.UpdateTakenServices(PostTakenService).subscribe(up => {
      this.getAllTakenServices();
    });
  }
  PopulateTakenServices(POP: TakenServices) {
    this.PostTakenService = POP
  }
}



//import { Component, OnInit } from '@angular/core';
//import { Router } from '@angular/router';
//import { TakenServices } from '../../models/taken-services';
//import { TakenServicesService } from '../../service/taken-services.service';

//@Component({
//  selector: 'app-taken-services',
//  templateUrl: './taken-services.component.html',
//  styleUrls: ['./taken-services.component.css']
//})

//export class TakenServicesComponent implements OnInit {
//  TakenServices: TakenServices[] = [];
//  PostTakenService: TakenServices = {
//    takenServiceId: undefined,
//    takenServiceName: '',
//    date: new Date(),
//    patientID: undefined,
//    price: 0,
//    isComplete: true,
//    paidAmount: 0,
//    due: 0
//  };

//  constructor(private takenServicesService: TakenServicesService, private router: Router) { }

//  ngOnInit() {
//    this.getAllTakenServices();
//  }

//  getAllTakenServices() {
//    this.takenServicesService.GetAllTakenServices().subscribe(data => {
//      this.TakenServices = data;
//    });
//  }

//  calculateDue() {
//    this.PostTakenService.due = this.PostTakenService.price - this.PostTakenService.paidAmount;
//  }

//  postTakenService() {
//    // Calculate the due before posting
//    this.calculateDue();

//    // Post the data to the service
//    this.takenServicesService.PostTakenServices(this.PostTakenService).subscribe(data => {
//      this.TakenServices.push(data);

//      // Reset the form
//      this.PostTakenService = {
//        takenServiceId: undefined,
//        takenServiceName: '',
//        date: new Date(),
//        patientID: undefined,
//        price: 0,
//        isComplete: true,
//        paidAmount: 0,
//        due: 0
//      };
//    });
//  }
//}
