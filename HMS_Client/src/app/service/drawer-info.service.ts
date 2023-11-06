import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DrawerInfo } from '../models/drawer-info';


@Injectable({
  providedIn: 'root'
})
export class DrawerInfoService {

  constructor(private http: HttpClient) { }

  GetAllDrawerInfo(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/DrawerInfo");
  }
  PostDrawerInfo(modell: DrawerInfo): Observable<DrawerInfo> {
    return this.http.post<DrawerInfo>("http://localhost:5041/api/DrawerInfo/", modell)
  }
  UpdateDrawerInfo(modell: DrawerInfo): Observable<DrawerInfo> {
    return this.http.put<DrawerInfo>("http://localhost:5041/api/DrawerInfo/" + modell.drawerInfoID, modell);
  }
  DeleteDrawerInfo(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/DrawerInfo/" + id);
  }
}
