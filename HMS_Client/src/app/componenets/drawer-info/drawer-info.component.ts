import { Component } from '@angular/core';
import { DrawerInfo } from '../../models/drawer-info';
import { DrawerInfoService } from '../../service/drawer-info.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-drawer-info',
  templateUrl: './drawer-info.component.html',
  styleUrls: ['./drawer-info.component.css']
})
export class DrawerInfoComponent {
  drawerInfo: any;

  PostDrawerInfo: DrawerInfo = {
    drawerInfoID: undefined,
    receivedDate: new Date(),
    releaseDate: new Date(),
    isPatient: true,
    drawerID: undefined,
    drawer: undefined,
    patientID: undefined,
    patientRegister: undefined,
    unidentifiedDeadBodyID: undefined,
    unidentifiedDeadBody: undefined
  }
  constructor(private DrawerInfoService: DrawerInfoService, private route: Router) { }
  ngOnInit() {
    this.GetAllDrawerInfo();
  }
  GetAllDrawerInfo() {
    this.DrawerInfoService.GetAllDrawerInfo().subscribe(i => {
      this.drawerInfo = i;
    });
  }
  insertDrawerInfo() {
    if (this.PostDrawerInfo.drawerInfoID === undefined) {
      this.DrawerInfoService.PostDrawerInfo(this.PostDrawerInfo).subscribe(i => {
        console.log(i);
        this.route.navigate(['/drawerInfo']);
        this.GetAllDrawerInfo();
        this.PostDrawerInfo = {
          drawerInfoID: undefined,
          receivedDate: new Date(),
          releaseDate: new Date(),
          isPatient: true,
          drawerID: undefined,
          drawer: undefined,
          patientID: undefined,
          patientRegister: undefined,
          unidentifiedDeadBodyID: undefined,
          unidentifiedDeadBody: undefined
        }
      });
    }
    else {
      this.UpdateDrawerInfo(this.PostDrawerInfo)
      this.PostDrawerInfo = {
        drawerInfoID: undefined,
        receivedDate: new Date(),
        releaseDate: new Date(),
        isPatient: true,
        drawerID: undefined,
        drawer: undefined,
        patientID: undefined,
        patientRegister: undefined,
        unidentifiedDeadBodyID: undefined,
        unidentifiedDeadBody: undefined
      }
    }
  }

  UpdateDrawerInfo(PostDrawerInfo: DrawerInfo) {
    this.DrawerInfoService.UpdateDrawerInfo(PostDrawerInfo).subscribe(i => {
      this.GetAllDrawerInfo();
    });
  }
  DrawerInfoDelete(id: number) {
    this.DrawerInfoService.DeleteDrawerInfo(id).subscribe(i => {
      this.route.navigate(['/drawerInfo']);
      this.GetAllDrawerInfo();
    })
  }
  PopulateDrawerInfo(POP: DrawerInfo) { this.PostDrawerInfo = POP }
}
