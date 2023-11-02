//import { Component } from '@angular/core';
//import { Services } from '../../models/services'
//import { Router } from '@angular/router';
//import { ServicesService } from '../../service/services.service';
//@Component({
//  selector: 'app-service',
//  templateUrl: './service.component.html',
//  styleUrls: ['./service.component.css']
//})
//export class ServiceComponent {
//  Service: any;
//  POSTService: Services = {
//    serviceID: undefined,
//    serviceName: '',
//    serviceCharge: 0
//  }
//  constructor(private serve: ServicesService, private route: Router) { }
//  ngOnInit() {
//    this.GetAllService();
//  }
//  GetAllService() {
//    this.serve.GetAllService().subscribe(s => {
//      this.Service = s;
//    });
//  }
//  insertService() {
//    if (this.POSTService.serviceID === undefined) {
//      this.serve.PostService(this.POSTService).subscribe(p => {
//        console.log(p);
//        this.route.navigate(['/service']);
//        this.GetAllService();
//        this.POSTService = {
//          serviceID: undefined,
//          serviceName: '',
//          serviceCharge: 0
//        }
//      });
//    }
//    else {
//      this.UpdateService(this.POSTService)
//      this.POSTService = {
//        serviceID: undefined,
//        serviceName: '',
//        serviceCharge: 0
//      }
//    }
//  }
//  UpdateService(POSTService: Services) {
//    this.serve.UpdateService(POSTService).subscribe(up => {
//      this.GetAllService();
//    });
//  }
//  ServiceDelete(id: number) {
//    this.serve.DeleteService(id).subscribe(d => {
//      this.route.navigate(['/service']);
//      this.GetAllService();
//    })
//  }
//  PopulateService(POP: Services) {
//    this.POSTService = POP
//  }
//}

import { Component } from '@angular/core';
import { Services } from '../../models/services';
import { Router } from '@angular/router';
import { ServicesService } from '../../service/services.service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent {
  Service: any;
  POSTService: Services = {
    serviceID: undefined,
    serviceName: '',
    serviceCharge: 0
  };

  constructor(private serve: ServicesService, private route: Router) { }

  ngOnInit() {
    this.GetAllService();
  }

  GetAllService() {
    this.serve.GetAllService().subscribe(
      (s) => {
        this.Service = s;
      },
      (error) => {
        console.error('Error while fetching services: ', error);
        // Handle the error as needed, e.g., show an error message.
      }
    );
  }

  insertService() {
    if (this.POSTService.serviceID === undefined) {
      this.serve.PostService(this.POSTService).subscribe(
        (p) => {
          console.log(p);
          // Successful insert, navigate back to 'service' page
          this.route.navigate(['/service']).then(() => {
            this.GetAllService(); // Refresh the service list
          });
          this.POSTService = {
            serviceID: undefined,
            serviceName: '',
            serviceCharge: 0
          };
        },
        (error) => {
          console.error('Error while inserting service: ', error);
          // Handle the error as needed, e.g., show an error message.
        }
      );
    } else {
      this.UpdateService(this.POSTService);
      this.POSTService = {
        serviceID: undefined,
        serviceName: '',
        serviceCharge: 0
      };
    }
  }

  UpdateService(POSTService: Services) {
    this.serve.UpdateService(POSTService).subscribe(
      (up) => {
        // Successful update, navigate back to 'service' page
        this.route.navigate(['/service']).then(() => {
          this.GetAllService(); // Refresh the service list
        });
      },
      (error) => {
        console.error('Error while updating service: ', error);
        // Handle the error as needed, e.g., show an error message.
      }
    );
  }

  ServiceDelete(id: number) {
    this.serve.DeleteService(id).subscribe(
      (d) => {
        // Successful deletion, navigate back to 'service' page
        this.route.navigate(['/service']).then(() => {
          this.GetAllService(); // Refresh the service list
        });
      },
      (error) => {
        console.error('Error while deleting service: ', error);
        // Handle the error as needed, e.g., show an error message.
      }
    );
  }

  PopulateService(POP: Services) {
    this.POSTService = POP;
  }
}
