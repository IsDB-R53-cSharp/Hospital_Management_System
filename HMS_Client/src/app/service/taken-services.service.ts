import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TakenServices } from '../models/taken-services';

@Injectable({
  providedIn: 'root'
})
export class TakenServicesService {

  constructor(private http: HttpClient) { }

  GetAllTakenServices(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/TakenServices");
  }
  PostTakenServices(modell: TakenServices): Observable<TakenServices> {
    return this.http.post<TakenServices>("http://localhost:5041/api/TakenServices", modell)
  }

  UpdateTakenServices(modell: TakenServices): Observable<TakenServices> {
    return this.http.put<TakenServices>("http://localhost:5041/api/TakenServices/" + modell.takenServiceId, modell);
  }

  DeleteTakenServices(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/TakenServices/" + id);
  }
}
