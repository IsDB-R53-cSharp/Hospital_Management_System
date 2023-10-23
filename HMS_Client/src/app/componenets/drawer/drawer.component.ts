import { Component } from '@angular/core';
import { Drawer } from '../../models/drawer';
import { Router } from '@angular/router';
import { DrawerService } from '../../service/drawer.service';

@Component({
  selector: 'app-drawer',
  templateUrl: './drawer.component.html',
  styleUrls: ['./drawer.component.css']
})
export class DrawerComponent {
  drawer: any;

  POSTDrawer: Drawer = {
    drawerID: undefined,
    drawerNo: '',
    drawerCondition: undefined,
    isOccupied: undefined,
    morgueID: undefined,
    morgue: null
  }
  constructor(private DrawerService: DrawerService, private route: Router) { }
  ngOnInit() {
    this.GetAllDrawer();
  }
  GetAllDrawer() {
    this.DrawerService.GetAllDrawer().subscribe(d => {
      this.drawer = d;
    });
  }
  insertDrawer() {
    if (this.POSTDrawer.drawerID === undefined) {
      this.DrawerService.PostDrawer(this.POSTDrawer).subscribe(d => {
        console.log(d);
        this.route.navigate(['/drawer']);
        this.GetAllDrawer();
        this.POSTDrawer = {
          drawerID: undefined,
          drawerNo: '',
          drawerCondition: undefined,
          isOccupied: undefined,
          morgueID: undefined,
          morgue: null
        }
      });
    }
    else {
      this.UpdateDrawer(this.POSTDrawer)
      this.POSTDrawer = {
        drawerID: undefined,
        drawerNo: '',
        drawerCondition: undefined,
        isOccupied: undefined,
        morgueID: undefined,
        morgue: null
      }
    }
  }

  UpdateDrawer(POSTDrawer: Drawer) {
    this.DrawerService.UpdateDrawer(POSTDrawer).subscribe(d => {
      this.GetAllDrawer();
    });
  }
  DrawerDelete(id: number) {
    this.DrawerService.DeleteDrawer(id).subscribe(w => {
      this.route.navigate(['/drawer']);
      this.GetAllDrawer();
    })
  }
  PopulateDrawer(POP: Drawer) { this.POSTDrawer = POP }
}
