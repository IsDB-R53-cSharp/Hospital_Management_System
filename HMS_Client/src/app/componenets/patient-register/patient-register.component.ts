import { Component } from '@angular/core';
import { PatientRegister } from '../../models/patient-register';
import { PatientRegisterService } from '../../service/patient-register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-register',
  templateUrl: './patient-register.component.html',
  styleUrls: ['./patient-register.component.css']
})
export class PatientRegisterComponent {
  Patient: any;
  POSTPatient: PatientRegister = {
    patientID: undefined,
    patientIdentityNumber: '',
    patientName: '',
    gender: 1,
    address: '',
    phoneNumber: '',
    email: '',


  }
  constructor(private serve: PatientRegisterService, private route: Router) { }
  ngOnInint() {
    this.getpatients();
  }
  getpatients() {
    this.serve.getAllPatients().subscribe(s => { this.Patient = s; });
  }

  InsertPatient() {
    if (this.POSTPatient.patientID === undefined) {
      this.serve.PostPatient(this.POSTPatient).subscribe(p => {
        console.log(p);
        this.route.navigate(['/patientRegister']);
        this.getpatients();
        this.POSTPatient = {
          patientID: undefined,
          patientIdentityNumber: '',
          patientName: '',
          gender: 1,
          address: '',
          phoneNumber: '',
          email: ''
        }
      });
    }
    else {
      this.patientUpdate(this.POSTPatient)
      this.POSTPatient = {
        patientID: undefined,
        patientIdentityNumber: '',
        patientName: '',
        gender: 1,
        address: '',
        phoneNumber: '',
        email: ''
      }
    }
  }
  patientUpdate(POSTPatient: PatientRegister) {
    this.serve.updatePatient(POSTPatient).subscribe(up => {
      this.getpatients();
    });
  }

  PatientDelete(id: number) {
    this.serve.deletePatient(id).subscribe(d => {
      this.route.navigate(['/patientRegister']);
      this.getpatients();
    });
  }
  populatePatient(POP: PatientRegister) {
    this.POSTPatient = POP
  }
}
//export class PatientRegisterComponent {
//  patients: any;
//  //newPatient: PatientRegister = new PatientRegister();
//  //editingPatient: PatientRegister | null = null;

//  constructor(private patientService: PatientRegisterService) { }

//  ngOnInit() {
//    this.loadPatients();
//  }

//  loadPatients() {
//    this.patientService.getAllPatients().subscribe(data => {
//      this.patients = data;
//    });
//  }

//  addPatient() {
//    this.patientService.createPatient(this.newPatient).subscribe(patient => {
//      this.patients.push(patient);
//      this.newPatient = new PatientRegister();
//    });
//  }

//  editPatient(patient: PatientRegister) {
//    this.editingPatient = patient;
//  }

//  //updatePatient() {
//  //  if (this.editingPatient) {
//  //    this.patientService.updatePatient(this.editingPatient.patientID, this.editingPatient).subscribe(patient => {
//  //      this.editingPatient = null;
//  //    });
//  //  }
//  //}

//  cancelEdit() {
//    this.editingPatient = null;
//  }

//  DeletePatient(id: number) {
//    this.patientService.deletePatient(id).subscribe(() => {
//      this.patients = this.patients.filter(p => p.patientID !== id);
//    });
//  }
//}
