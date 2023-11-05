import { Component } from '@angular/core';
import { WasteManagement } from '../../models/waste-management';
import { WasteManagementService } from '../../service/waste-management.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-waste-management',
  templateUrl: './waste-management.component.html',
  styleUrls: ['./waste-management.component.css']
})
export class WasteManagementComponent {
  waste: any;

  POSTWasteManagement: WasteManagement = {
    wasteID: undefined,
    wasteType: 1,
    disposalDate: undefined,
    quantity: 0,
    nextScheduleDate: undefined,
    contactNumber: ''
  }
  constructor(private WasteService: WasteManagementService, private route: Router) { }
  ngOnInit() {
    this.GetAllWasteManagement();
  }
  GetAllWasteManagement() {
    this.WasteService.GetAllWasteManagement().subscribe(w => {
      this.waste = w;
    });
  }
  insertWasteManagement() {
    if (this.POSTWasteManagement.wasteID === undefined) {
      this.WasteService.PostWasteManagement(this.POSTWasteManagement).subscribe(w => {
        console.log(w);
        this.route.navigate(['/WasteManagement']);
        this.GetAllWasteManagement();
        this.POSTWasteManagement = {
          wasteID: undefined,
          wasteType: 1,
          disposalDate: undefined,
          quantity: 0,
          nextScheduleDate: undefined,
          contactNumber: ''
        }
      });
    }
    else {
      this.UpdateWasteManagement(this.POSTWasteManagement)
      this.POSTWasteManagement = {
        wasteID: undefined,
        wasteType: 1,
        disposalDate: undefined,
        quantity: 0,
        nextScheduleDate: undefined,
        contactNumber: ''
      }
    }
  }

  UpdateWasteManagement(POSTWasteManagement: WasteManagement) {
    this.WasteService.UpdateWasteManagement(POSTWasteManagement).subscribe(w => {
      this.GetAllWasteManagement();
    });
  }
  WasteManagementDelete(id: number) {
    this.WasteService.DeleteWasteManagement(id).subscribe(w => {
      this.route.navigate(['/WasteManagement']);
      this.GetAllWasteManagement();
    })
  }
  //WasteManagementDetails(id: number) {
  //  this.WasteService.WasteManagementDetails(id).subscribe(w => {
  //    this.route.navigate(['/WasteManagement']);
  //    this.GetAllWasteManagement();
  //  })
  //}
  PopulateWasteManagement(POP: WasteManagement) { this.POSTWasteManagement = POP }
}
