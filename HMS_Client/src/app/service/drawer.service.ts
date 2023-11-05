import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Drawer } from '../models/drawer';
import { Morgue } from '../models/morgue';


@Injectable({
  providedIn: 'root'
})
export class DrawerService {

  constructor(private http: HttpClient) { }

  GetAllDrawer(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Drawers");
  }
  PostDrawer(modell: Drawer): Observable<Drawer> {
    return this.http.post<Drawer>("http://localhost:5041/api/Drawers", modell)
  }
  UpdateDrawer(modell: Drawer): Observable<Drawer> {
    return this.http.put<Drawer>("http://localhost:5041/api/Drawers/" + modell.drawerID, modell);
  }
  DeleteDrawer(id: number): Observable<any> {
    return this.http.delete<any>("http://localhost:5041/api/Drawers/" + id);
  }
  GetAllMorgue(): Observable<any> {
    return this.http.get<any>("http://localhost:5041/api/Morgue");
  }
  PostMorgue(modell: Morgue): Observable<Morgue> {
    return this.http.post<Morgue>("http://localhost:5041/api/Morgue", modell)
  }
  UpdateMorgue(modell: Morgue): Observable<Morgue> {
    return this.http.put<Morgue>("http://localhost:5041/api/Morgue/" + modell.morgueID, modell);
  }
 
}
