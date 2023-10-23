import { Component } from '@angular/core';
import { Services } from '../../models/services';
import { ServicesService } from '../../service/services.service';
import { Router } from '@angular/router';

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
  }
  constructor(private serve: ServicesService, private route: Router) { }
  ngOnInit() {
    this.GetAllService();
  }
  GetAllService() {
    this.serve.GetAllService().subscribe(s => {
      this.Service = s;
    });
  }
  insertService() {
    if (this.POSTService.serviceID === undefined) {
      this.serve.PostService(this.POSTService).subscribe(p => {
        console.log(p);
        this.route.navigate(['/service']);
        this.GetAllService();
        this.POSTService = {
          serviceID: undefined,
          serviceName: '',
          serviceCharge: 0
        }
      });
    }
    else {
      this.UpdateService(this.POSTService)
      this.POSTService = {
        serviceID: undefined,
        serviceName: '',
        serviceCharge: 0
      }
    }
  }
  UpdateService(POSTService: Services) {
    this.serve.UpdateService(POSTService).subscribe(up => {
      this.GetAllService();
    });
  }
  ServiceDelete(id: number) {
    this.serve.DeleteService(id).subscribe(d => {
      this.route.navigate(['/service']);
      this.GetAllService();
    })
  }
  PopulateService(POP: Services) {
    this.POSTService = POP
  }
}
