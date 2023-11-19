import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Ambulance } from '../models/ambulance';

@Injectable({
  providedIn: 'root'
})
export class AmbulanceService {
  constructor(private http: HttpClient) { }
  GetAllAmbulance(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Ambulances");
  }
  PostAmbulance(modell: Ambulance): Observable<Ambulance> {
    return this.http.post<Ambulance>("http://localhost:5041/api/Ambulances", modell)
  }
  UpdateAmbulance(modell: Ambulance): Observable<Ambulance> {
    return this.http.put<Ambulance>("http://localhost:5041/api/Ambulances/" + modell.ambulanceID, modell);
  }
  DeleteAmbulance(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/Ambulances/" + id);
  }
}
