import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DrawerInfo } from '../models/drawer-info';
import { UnIdenfiedDeadBody } from '../models/un-idenfied-dead-body';
import { PatientRegister } from '../models/patient-register';
import { Drawer } from '../models/drawer';



@Injectable({
  providedIn: 'root'
})
export class DrawerInfoService {

  constructor(private http: HttpClient) { }

  GetAllDrawerInfo(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/DrawerInfo/GetDrawerInfo");
  }
  PostDrawerInfo(modell: DrawerInfo): Observable<DrawerInfo> {
    return this.http.post<DrawerInfo>("http://localhost:5041/api/DrawerInfo/Insert", modell)
  }
  UpdateDrawerInfo(modell: DrawerInfo): Observable<DrawerInfo> {
    return this.http.put<DrawerInfo>("http://localhost:5041/api/DrawerInfo/Update/" + modell.drawerInfoID, modell);
  }
  DeleteDrawerInfo(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/DrawerInfo/Delete/" + id);
  }
  GetAllUnIdenfiedDeadBody(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/UnidentifiedDeadBodys");
  }
  PostUnIdenfiedDeadBody(modell: UnIdenfiedDeadBody): Observable<UnIdenfiedDeadBody> {
    return this.http.post<UnIdenfiedDeadBody>("http://localhost:5041/api/UnidentifiedDeadBodys", modell)
  }
  UpdateUnIdenfiedDeadBody(modell: UnIdenfiedDeadBody): Observable<UnIdenfiedDeadBody> {
    return this.http.put<UnIdenfiedDeadBody>("http://localhost:5041/api/UnidentifiedDeadBodys/" + modell.unIdenfiedDeadBodyID, modell);
  }
  getAllPatients(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Patient");
  }

  PostPatient(patient: PatientRegister): Observable<PatientRegister> {
    return this.http.post<PatientRegister>("http://localhost:5041/api/Patient", patient);
  }

  updatePatient(patient: PatientRegister): Observable<PatientRegister> {
    return this.http.put<PatientRegister>("http://localhost:5041/api/Patient/" + patient.patientID, patient);
  }
  GetAllDrawer(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Drawers/GetDrawer");
  }
  PostDrawer(modell: Drawer): Observable<Drawer> {
    return this.http.post<Drawer>("http://localhost:5041/api/Drawers/Insert", modell)
  }
  UpdateDrawer(modell: Drawer): Observable<Drawer> {
    return this.http.put<Drawer>("http://localhost:5041/api/Drawers/Update/" + modell.drawerID, modell);
  }
}