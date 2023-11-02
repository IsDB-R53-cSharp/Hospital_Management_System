import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Services } from '../models/services';


@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http: HttpClient) { }
  GetAllService(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Services/GetServices");
  }
  PostService(modell: Services): Observable<Services> {
    return this.http.post<Services>("http://localhost:5041/api/Services/CreateService", modell)
  }
  UpdateService(modell: Services): Observable<Services> {
    return this.http.put<Services>("http://localhost:5041/api/Services/UpdateService/" + modell.serviceID, modell);
  }
  //DeleteService(id: number): Observable<any> {
  //  return this.http.delete<any>("http://localhost:5041/api/Services/DeleteService" + id);
  //}
  DeleteService(id: number): Observable<any> {
    return this.http.delete<any>(`http://localhost:5041/api/Services/DeleteService/${id}`);
  }

}
