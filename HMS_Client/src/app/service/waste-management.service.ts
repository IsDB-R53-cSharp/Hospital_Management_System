import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WasteManagement } from '../models/waste-management';


@Injectable({
  providedIn: 'root'
})
export class WasteManagementService {

  constructor(private http: HttpClient) { }

  GetAllWasteManagement(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/WasteManagement");
  }
  PostWasteManagement(modell: WasteManagement): Observable<WasteManagement> {
    return this.http.post<WasteManagement>("http://localhost:5041/api/WasteManagement", modell)
  }
  UpdateWasteManagement(modell: WasteManagement): Observable<WasteManagement> {
    return this.http.put<WasteManagement>("http://localhost:5041/api/WasteManagement/" + modell.wasteID, modell);
  }
  DeleteWasteManagement(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/WasteManagement/" + id);
  }
  //WasteManagementDetails(id: number): Observable<any> {
  //  return this.http.get<any>("http://localhost:5041/api/WasteManagement" + id);
  //}
}
