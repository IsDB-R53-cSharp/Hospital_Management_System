//import { Injectable } from '@angular/core';

//@Injectable({
//  providedIn: 'root'
//})
//export class PatientRegisterService {

//  constructor() { }
//}


import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PatientRegister } from '../models/patient-register';

@Injectable({
  providedIn: 'root',
})
export class PatientRegisterService {


  constructor(private http: HttpClient) { }

  //getPatient(id: number): Observable<PatientRegister> {
  //  return this.http.get<PatientRegister>(`http://localhost:5041/api/Patient/${id}`);
  //}

  getAllPatients(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Patient");
  }

  PostPatient(patient: PatientRegister): Observable<PatientRegister> {
    return this.http.post<PatientRegister>("http://localhost:5041/api/Patient", patient);
  }

  updatePatient(patient: PatientRegister): Observable<PatientRegister> {
    return this.http.put<PatientRegister>("http://localhost:5041/api/Patient/" + patient.patientID, patient);
  }

  deletePatient(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/Patient/" + id);
  }
}

