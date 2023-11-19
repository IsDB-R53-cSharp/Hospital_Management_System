import { Component } from '@angular/core';
import { Ambulance } from '../../models/ambulance';
import { AmbulanceService } from '../../service/ambulance.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ambulance',
  templateUrl: './ambulance.component.html',
  styleUrls: ['./ambulance.component.css']
})
export class AmbulanceComponent {
  Ambulance: any;
  PostAmbulance: Ambulance = {
    ambulanceID: undefined,
    ambulanceNumber: '',
    lastLocation: '',
    availability: undefined
  }

  constructor(private aServ: AmbulanceService, private route: Router) { }
  ngOnInit() {
    this.AllAmbulance();
  }
  AllAmbulance() {
    this.aServ.GetAllAmbulance().subscribe(a => {
      this.Ambulance = a;
    });
  }
  insertAmbulance() {
    if (this.PostAmbulance.ambulanceID === undefined) {
      this.aServ.PostAmbulance(this.PostAmbulance).subscribe(p => {
        console.log(p);
        this.route.navigate(['/Ambulance']);
        this.AllAmbulance();
        this.PostAmbulance = {
          ambulanceID: undefined,
          ambulanceNumber: '',
          lastLocation: '',
          availability: undefined
        }
      });
    }
    else {
      this.UpdateAmbulance(this.PostAmbulance)
      this.PostAmbulance = {
        ambulanceID: undefined,
        ambulanceNumber: '',
        lastLocation: '',
        availability: undefined
      }
    }
  }
  UpdateAmbulance(PostAmbulance: Ambulance) {
    this.aServ.UpdateAmbulance(PostAmbulance).subscribe(up => {
      this.AllAmbulance();
    });
  }
  AmbulanceDelete(id: number) {
    this.aServ.DeleteAmbulance(id).subscribe(d => {
      this.route.navigate(['/Ambulance']);
      this.AllAmbulance();
    })
  }
  PopulateAmbulance(POP: Ambulance) { this.PostAmbulance = POP }
}
