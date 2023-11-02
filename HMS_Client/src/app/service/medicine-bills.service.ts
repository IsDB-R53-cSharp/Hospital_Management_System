import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MedicineBills } from '../models/medicine-bills';

@Injectable({
  providedIn: 'root'
})
export class MedicineBillsService {

  constructor(private http: HttpClient) { }
  GetAllMedicineBills(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/MedicineBills");
  }
  PostMedicineBills(modell: MedicineBills): Observable<MedicineBills> {
    return this.http.post<MedicineBills>("http://localhost:5041/api/MedicineBills", modell)
  }

  UpdateMedicineBills(modell: MedicineBills): Observable<MedicineBills> {
    return this.http.put<MedicineBills>("http://localhost:5041/api/MedicineBills/" + modell.medicineBillId, modell);
  }

  DeleteMedicineBills(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/MedicineBills/" + id);
  }
}
